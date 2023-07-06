using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SuperBowlWeb.Data;
using SuperBowlWeb.Models;
using SuperBowlWeb.Models.Constantes;
using System.ComponentModel;

namespace SuperBowlWeb.Controllers
{
    public class JeuxController : BaseApiController
    {
        private readonly SuperBowlWebContext _context;
        private readonly IMapper _mapper;

        public JeuxController(SuperBowlWebContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: Jeux        
        [HttpGet]
        public async Task<IActionResult> List()
        {
            
            var superBowlWebContext = await _context.Jeux.Include(m => m.EquipeA).Include(m => m.EquipeB).ToListAsync();
            if (superBowlWebContext == null)
            {
                return NotFound("No entity found in DB ??");
            }
            return Ok(superBowlWebContext);

        }

        [HttpGet]
        [Route("dujour")]
        public async Task<IActionResult> ListMatchDuJour()
        {
            var hier = DateTime.Parse(DateTime.Today.AddDays(-1).ToShortDateString());
            var aujourdui = DateTime.Parse(DateTime.Today.ToShortDateString());
            
            var superBowlWebContext = await _context.Jeux.Where(x => (x.DateRencontre > hier) && (x.DateRencontre <= aujourdui))
                                                            .Include(m => m.EquipeA)
                                                            .Include(m => m.EquipeB)
                                                            .ToListAsync();
            if (superBowlWebContext == null)
            {
                return NotFound("No entity found in DB ??");
            }
            return Ok(superBowlWebContext);
        }
        [Authorize]
        // Get by id 
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var jeuDetails = await _context.Jeux
                                            .ProjectTo<Jeu>(_mapper.ConfigurationProvider)
                                            .FirstOrDefaultAsync(x => x.Id == id);
            if (jeuDetails == null)
            {
                return NotFound("No entity found in DB ??");
            }
            return Ok(jeuDetails);
        }

        private bool MatchExists(int id)
        {
            return (_context.Jeux?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
