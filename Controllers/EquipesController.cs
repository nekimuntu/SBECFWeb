using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperBowlWeb.Controllers.DTO;
using SuperBowlWeb.Data;
using SuperBowlWeb.Models;
using SuperBowlWeb.Models.Constantes;

namespace SuperBowlWeb.Controllers
{
    public class EquipesController : BaseApiController
    {
        private readonly SuperBowlWebContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<Utilisateur> _userManager;

        public EquipesController(SuperBowlWebContext context,IMapper mapper, UserManager<Utilisateur> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        //Create a team 
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateTeam(JoueursEquipe joueursEquipe)
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
            if(user.Role == (int)RoleUser.Admin)
            {
                Equipe equipe = joueursEquipe.Equipe;
                List<Joueur> joueurs = joueursEquipe.Joueurs;
                try
                {
                    await _context.AddAsync(equipe);
                    await _context.AddAsync(joueurs);
                    var result = await _context.SaveChangesAsync();
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Unauthorized("Tu n'est pas admin");
        }

        [HttpPut]
        [Route("create")]
        public async Task<ActionResult> UpdateTeam(Equipe joueursEquipe)
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
            if (user.Role == (int)RoleUser.Admin)
            {
                Equipe equipe = await _context.Equipe.FirstOrDefaultAsync(x => x.Id == joueursEquipe.Id);

                _mapper.Map<Equipe, Equipe>(joueursEquipe, equipe);
                try
                {
                    _context.Update(equipe);
                    var result = _context.SaveChanges() > 0;
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);  
                }
                return Ok(" equipe bien enregistre");
            }
            return Unauthorized("Tu n'est pas admin");
        }

        [AllowAnonymous]
        // GET: Equipes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if ( _context.Equipe == null)
            {
                return NotFound();
            }
            if(id == null || id == 0)
            {
                var equipes = await _context.Equipe.ProjectTo<EquipeDTO>(_mapper.ConfigurationProvider).ToListAsync();
                
                return Ok(equipes);
            }

            var equipe = await _context.Equipe
                .ProjectTo<EquipeDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(m => m.Id == id);
            equipe.Joueurs = await _context.Joueur
                                            .ProjectTo<JoueurDTO>(_mapper.ConfigurationProvider)
                                            .Where(x=>x.EquipeId == equipe.Id)
                                            .ToListAsync();
            if (equipe == null)
            {
                return NotFound();
            }

            return Ok(equipe);
        }

       
    }
}
