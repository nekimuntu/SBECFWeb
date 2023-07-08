using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperBowlWeb.Data;
using SuperBowlWeb.Models;

namespace SuperBowlWeb.Controllers
{
    public class EquipesController : BaseApiController
    {
        private readonly SuperBowlWebContext _context;
        private readonly IMapper _mapper;

        public EquipesController(SuperBowlWebContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
