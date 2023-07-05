using AutoMapper;
using AutoMapper.QueryableExtensions;
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
            var statutMatch = Statut.Termine;

            var superBowlWebContext = await _context.Jeux.Include(m => m.EquipeA).Include(m => m.EquipeB).ToListAsync();
            if (superBowlWebContext == null)
            {
                return NotFound("No entity found in DB ??");
            }
            return Ok(superBowlWebContext);

        }

        [HttpGet]
        [Route("dujour")]
        public async Task<IActionResult> ListTermine()
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

        // Get by id 
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var jeuDetails = await _context.Jeux
                                            .ProjectTo<EquipeDTO>(_mapper.ConfigurationProvider)
                                            .FirstOrDefaultAsync(x => x.Id == id);
            if (jeuDetails == null)
            {
                return NotFound("No entity found in DB ??");
            }
            return Ok(jeuDetails);
        }

        //// GET: Jeux/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Jeux == null)
        //    {
        //        return NotFound();
        //    }

        //    var match = await _context.Jeux
        //        .Include(m => m.EquipeA)
        //        .Include(m => m.EquipeB)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (match == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(match);
        //}

        //// GET: Jeux/Create
        //public IActionResult Create()
        //{
        //    ViewData["EquipeAId"] = new SelectList(_context.Set<Equipe>(), "Id", "Id");
        //    ViewData["EquipeBId"] = new SelectList(_context.Set<Equipe>(), "Id", "Id");
        //    return View();
        //}

        //// POST: Jeux/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,EquipeAId,EquipeBId,DateRencontre,HeureDebut,HeureFin,ScoreEquipeA,ScoreEquipeB,EquipeGagnante,Commentaires")] SuperBowlWeb.Models.Jeu jeu)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(jeu);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["EquipeAId"] = new SelectList(_context.Set<Equipe>(), "Id", "Id", jeu.EquipeAId);
        //    ViewData["EquipeBId"] = new SelectList(_context.Set<Equipe>(), "Id", "Id", jeu.EquipeBId);
        //    return View(jeu);
        //}

        //// GET: Jeux/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Jeux == null)
        //    {
        //        return NotFound();
        //    }

        //    var match = await _context.Jeux.FindAsync(id);
        //    if (match == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["EquipeAId"] = new SelectList(_context.Set<Equipe>(), "Id", "Id", match.EquipeAId);
        //    ViewData["EquipeBId"] = new SelectList(_context.Set<Equipe>(), "Id", "Id", match.EquipeBId);
        //    return View(match);
        //}

        //// POST: Jeux/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,EquipeAId,EquipeBId,DateRencontre,HeureDebut,HeureFin,ScoreEquipeA,ScoreEquipeB,EquipeGagnante,Commentaires")] SuperBowlWeb.Models.Jeu match)
        //{
        //    if (id != match.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(match);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!MatchExists(match.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["EquipeAId"] = new SelectList(_context.Set<Equipe>(), "Id", "Id", match.EquipeAId);
        //    ViewData["EquipeBId"] = new SelectList(_context.Set<Equipe>(), "Id", "Id", match.EquipeBId);
        //    return View(match);
        //}

        //// GET: Jeux/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Jeux == null)
        //    {
        //        return NotFound();
        //    }

        //    var match = await _context.Jeux
        //        .Include(m => m.EquipeA)
        //        .Include(m => m.EquipeB)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (match == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(match);
        //}

        //// POST: Jeux/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Jeux == null)
        //    {
        //        return Problem("Entity set 'SuperBowlWebContext.Match'  is null.");
        //    }
        //    var match = await _context.Jeux.FindAsync(id);
        //    if (match != null)
        //    {
        //        _context.Jeux.Remove(match);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool MatchExists(int id)
        {
            return (_context.Jeux?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
