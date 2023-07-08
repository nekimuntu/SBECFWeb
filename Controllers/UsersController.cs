using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SuperBowlWeb.Controllers.DTO;
using SuperBowlWeb.Data;
using SuperBowlWeb.Models;
using SuperBowlWeb.Services;
using System.Security.Claims;
using System.Security.Permissions;

namespace SuperBowlWeb.Controllers
{
    
    [ApiController]
    [Route("/api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<Utilisateur> _context;
        private readonly TokenService _tokenService;
        private readonly IMapper _mapper;

        public UsersController(Microsoft.AspNetCore.Identity.UserManager<Utilisateur> context, TokenService tokenService,IMapper mapper)
        {
            _context = context;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        [Route("/api/currentuser")]
        public async Task<ActionResult<UserDTO>> GetCurrentUser() {
            var user = await _context.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));           
            UserDTO userDto = CreateUserDto(user);
            return (userDto);
        }

        [AllowAnonymous]
        //Login 
        [HttpPost]
        [Route("/api/login")]
        
        public async Task<ActionResult<UserDTO>> Login(LoginDTO userDto)
        {
            if (_context.FindByEmailAsync(userDto.Email) == null)
            {
                return Unauthorized("Aucun utilisateur");
            }
            var user = await _context.FindByEmailAsync(userDto.Email);
            var result = await _context.CheckPasswordAsync(user, userDto.Password);
            if (result == false)
            {
                return Unauthorized();
            }

            UserDTO retour = CreateUserDto(user);

            return Ok(retour);
        }

        // POST:Creer un utilisateur
        [AllowAnonymous]
        [HttpPost]
        [Route("/api/register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO userRegister)
        {
            if (await _context.Users.AnyAsync(x => x.UserName == userRegister.UserName))
            {
                ModelState.AddModelError("username", "Username taken");
                return ValidationProblem(ModelState);
                // return BadRequest("Username already taken");
            }
            if (await _context.Users.AnyAsync(x => x.Email == userRegister.Email))
            {
                ModelState.AddModelError("email", "Email already taken");
                return ValidationProblem(ModelState);
            }
            var user = new Utilisateur
            {
                UserName = userRegister.UserName,
                Nom = userRegister.Nom,
                Prenom = userRegister.Prenom,
                Email = userRegister.Email,
                Role = userRegister.Role
            };
           

            var result = await _context.CreateAsync(user, userRegister.Password);
            if (result.Succeeded == false)
            {
                return BadRequest("Probleme lors de la creation du compte. "+result.Errors);
            }
            var retour = CreateUserDto(user);
            return Ok(retour);
        }

        [HttpPut]
        [Route("/api/update")] //mise a jour
        public async Task<ActionResult<UserDTO>> Update(UserDTO userDto)
        {
            if (_context.FindByEmailAsync(userDto.Email) != null)
            {
                return Unauthorized("Utilisateur deja enregistre");
            }
            var user = await _context.FindByEmailAsync(userDto.Email);
            

            var result = await _context.UpdateAsync(user);
            if (result.Succeeded == false)
            {
                return Unauthorized(result.Errors);
            }
           
            return Ok(userDto);
        }
        // GET: Liste des utilisateurs
        
        public async Task<ActionResult<List<Utilisateur>>> Index()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        // GET: Recuperer les details d un utilisateur
        [HttpGet("{username}")]
        //[Route("api/[Controller]/details/{username}")] cette route ne fonctionne pas ...
        public async Task<ActionResult<UserDTO>> Details(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=>x.UserName== username);
            if (user == null)
            {
                return BadRequest("Aucun utilisateur avec cet email");
            }
            var retour = CreateUserDto(user);

            return Ok(retour);
        }

        
        private UserDTO CreateUserDto(Utilisateur user)
        {
            var mapper = _mapper.ConfigurationProvider.CreateMapper();
            UserDTO userDto = mapper.Map<UserDTO>(user);
            userDto.Token = _tokenService.CreateToken(user);

            return userDto;
        }

        // DELETE: supprimer un utilisateur
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return Ok();
        }

    }
}
