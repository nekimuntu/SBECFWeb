using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperBowlWeb.Controllers.DTO;
using SuperBowlWeb.Data;
using SuperBowlWeb.Models;

namespace SuperBowlWeb.Controllers
{
    public class ParisController : BaseApiController
    {
        private readonly SuperBowlWebContext _context;
        private readonly Microsoft.AspNetCore.Identity.UserManager<Utilisateur> _userManager;
        private readonly IMapper _mapper;

        public ParisController(SuperBowlWebContext context,UserManager<Utilisateur> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        // GET: List de tous les Paris
        public async Task<IActionResult> getId()
        {
            if (_context.Pari.Any())
            {
                var superBowlWebContext = _context.Pari.Select(x=>x.Id).Max();

                return superBowlWebContext == null ? Ok(1): Ok(superBowlWebContext+1);
            }
            return Ok(1);
        
        }
        // GET: List de tous les Paris d un utilisateur
        [HttpGet("byuser/{userId}")]
        public async Task<IActionResult> ListByUserId(string userId)
        {
            if (_context.Pari.Any())
            {
                var parisUser = await _context.Pari.Where(x => x.UserId == userId).Include(x => x.EquipeMise).ToListAsync();
                return Ok(parisUser);
            }
            return NotFound("Pas encore de paris enregistre");
        }

        // GET: Le Paris d un utilisateur sur ce match
        [HttpGet("{email}/bymatch/{matchId}/")]
        public async Task<IActionResult> getByMatchId(int matchId,string email)
        {
            if (_context.Pari.Any())
            {
                if(email != null)
                {
                    var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
                    var pariUser = await _context.Pari.Where(x => x.MatchId == matchId)
                                                        .Where(x=>x.UserId==user.Id)
                                                        .Include(x => x.EquipeMise)
                                                        .Include(x => x.Jeu).ToListAsync();
                    return Ok(pariUser);
                }
                //var pariUser = await _context.Pari.Where(x => x.MatchId == matchId).Include(x => x.EquipeMise).Include(x=>x.Jeu).ToListAsync();
               
            }
            return NotFound("Pas encore de paris enregistre");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pari pari)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
                pari.UserId = user.Id;
                
                _context.Pari.Add(pari);
                try
                {
                    await _context.SaveChangesAsync();
                    return Ok(1);
                }catch (Exception ex)
                {
                    return BadRequest(ex.Message);  
                }
            }

            return NotFound(1);
        }

     
        private bool PariExists(int id)
        {
          return (_context.Pari?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
