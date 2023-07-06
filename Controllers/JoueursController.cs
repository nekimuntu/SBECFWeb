using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SuperBowlWeb.Data;
using SuperBowlWeb.Models;

namespace SuperBowlWeb.Controllers
{
    public class JoueursController : Controller
    {
        private readonly SuperBowlWebContext _context;
        private readonly IMapper _mapper;

        public JoueursController(SuperBowlWebContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Joueurs
        public async Task<IActionResult> Index()
        {
            var superBowlWebContext = _context.Joueur.Include(j => j.Equipe).Include(j => j.Pays);
            return View(await superBowlWebContext.ToListAsync());
        }

        // GET: Joueurs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Joueur == null)
            {
                return NotFound();
            }
            
            var joueurDto = await _context.Joueur
                                        .ProjectTo<JoueurDTO>(_mapper.ConfigurationProvider)
                                        .FirstOrDefaultAsync(x => x.Id == id);
            if (joueurDto == null)
            {
                return NotFound();
            }

            return Ok(joueurDto);
        }

       
        // POST: Joueurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Joueur joueur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(joueur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipeId"] = new SelectList(_context.Equipe, "Id", "Id", joueur.EquipeId);
            ViewData["PaysId"] = new SelectList(_context.Pays, "Id", "Id", joueur.PaysId);
            return View(joueur);
        }

        // POST: Joueurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, JoueurDTO joueurDto)
        {
            if (id != joueurDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var pays = await _context.Pays.FirstOrDefaultAsync(x => x.Name == joueurDto.Pays);
                    var joueur = await _context.Equipe.FirstOrDefaultAsync(x => x.Id == joueurDto.Id);
                    joueur.PaysId = pays.Id;
                    _context.Update(joueur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException error)
                {
                    if (!JoueurExists(joueurDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        NotFound(error.Message);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
  
            return Ok(joueurDto);
        }


        private bool JoueurExists(long id)
        {
          return (_context.Joueur?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
