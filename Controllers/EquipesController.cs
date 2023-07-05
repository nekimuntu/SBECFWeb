using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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

        // GET: Equipes
        //[HttpGet]
        //public async Task<IActionResult> List()
        //{
        //      var equipes = await _context.Equipe.Include(x=>x.Joueurs).ToListAsync();
        //    //var equipesDTO = new List<EquipeDTO>();
        //    //    equipes.ForEach(equipe => { 
        //    //    EquipeDTO equipeDTO = new EquipeDTO { 
        //    //        Id = equipe.Id,
        //    //        Nom = equipe.Nom,
        //    //        PaysId = equipe.PaysId,
        //    //        Pays = equipe.Pays.Name,
        //    //    };
        //    //    equipesDTO.Add(equipeDTO);
        //    //});
        //      return _context.Equipe != null ? 
        //                  Ok(equipes) :
        //                  NotFound("Entity set 'SuperBowlWebContext.Equipe'  is null.");
        //}

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

        // GET: Equipes/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Equipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Nom,PaysId")] Equipe equipe)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(equipe);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(equipe);
        //}

        //// GET: Equipes/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Equipe == null)
        //    {
        //        return NotFound();
        //    }

        //    var equipe = await _context.Equipe.FindAsync(id);
        //    if (equipe == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(equipe);
        //}

        //// POST: Equipes/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,PaysId")] Equipe equipe)
        //{
        //    if (id != equipe.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(equipe);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!EquipeExists(equipe.Id))
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
        //    return View(equipe);
        //}

        //// GET: Equipes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Equipe == null)
        //    {
        //        return NotFound();
        //    }

        //    var equipe = await _context.Equipe
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (equipe == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(equipe);
        //}

        //// POST: Equipes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Equipe == null)
        //    {
        //        return Problem("Entity set 'SuperBowlWebContext.Equipe'  is null.");
        //    }
        //    var equipe = await _context.Equipe.FindAsync(id);
        //    if (equipe != null)
        //    {
        //        _context.Equipe.Remove(equipe);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool EquipeExists(int id)
        //{
        //  return (_context.Equipe?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
