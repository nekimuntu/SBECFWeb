using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SuperBowlWeb.Controllers.DTO;
using SuperBowlWeb.Data;
using SuperBowlWeb.Models;

namespace SuperBowlWeb.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<Utilisateur> _context;

        public UsersController(Microsoft.AspNetCore.Identity.UserManager<Utilisateur> context)
        {
            _context = context;
        }

        //Login 
        [HttpPost]
        [Route("/api/login")]
        public async Task<IActionResult> Login(LoginDTO userDto)
        {
            if(_context.FindByEmailAsync(userDto.Email) == null) {
                return Unauthorized("Aucun utilisateur");
            }
            var user = await _context.FindByEmailAsync(userDto.Email);
            var result = await _context.CheckPasswordAsync(user,userDto.Password);
            if(result == false)
            {
                return Unauthorized();
            }

            var retour = new UserDTO { 
                            Username=user.UserName,
                            Nom = user.Nom,
                            Prenom = user.Prenom,
                            Email = user.Email,
                            Role = 0,
                            Token = "this is the token"
            };
            if (user.RoleAdmin.HasValue)
                retour.Role = 3;
            if (user.RoleCommentateur.HasValue)
                retour.Role = 2;
            if (user.RoleUtilisateur.HasValue)
                retour.Role = 1;

            return Ok(retour);
        }


        // POST:Creer un utilisateur
        [HttpPost]
        [Route("/api/register")]
        public async Task<IActionResult> Register(RegisterDTO userRegister)
        {
            if (_context.FindByEmailAsync(userRegister.Email) != null)
            {
                return Unauthorized("Utilisateur deja enregistre");
            }
            var user = new Utilisateur
            {
                Nom = userRegister.Nom,
                Prenom = userRegister.Prenom,
                Email = userRegister.Email,
            };
            if (userRegister.Role==3)
                user.RoleAdmin =true;
            if (userRegister.Role == 2)
                user.RoleCommentateur = true;
            if (userRegister.Role == 1)
                user.RoleUtilisateur = true;

            var result = await _context.CreateAsync(user, userRegister.Password);
            if (result.Succeeded == false)
            {
                return Unauthorized(result.Errors);
            }
            var retour = new UserDTO
            {
                Username = user.UserName,
                Nom = user.Nom,
                Prenom = user.Prenom,
                Email = user.Email,
                Role = userRegister.Role,
                Token = "this is the token"
            };
            return Ok(retour);
        }

        [HttpPut]
        [Route("/api/update")] //mise a jour
        public async Task<IActionResult> Update(UserDTO userDto)
        {
            if (_context.FindByEmailAsync(userDto.Email) != null)
            {
                return Unauthorized("Utilisateur deja enregistre");
            }
            var user = await _context.FindByEmailAsync(userDto.Email);
            
            if (userDto.Role == 3)
                user.RoleAdmin = true;
            if (userDto.Role == 2)
                user.RoleCommentateur = true;
            if (userDto.Role == 1)
                user.RoleUtilisateur = true;

            var result = await _context.UpdateAsync(user);
            if (result.Succeeded == false)
            {
                return Unauthorized(result.Errors);
            }
           
            return Ok(userDto);
        }
        // GET: Liste des utilisateurs
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        // GET: Recuperer les details d un utilisateur
        [HttpGet("{id}")]
        [Route("api/[Controller]/details/{id}")]
        public async Task<IActionResult> Details(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=>x.UserName== username);
            if (user == null)
            {
                return BadRequest("Aucun utilisateur avec cet email");
            }
            return Ok(user);
        }


        // DELETE: supprimer un utilisateur
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return Ok();
        }

    }
}
