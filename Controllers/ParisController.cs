using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperBowlWeb.Data;
using SuperBowlWeb.Models;

namespace SuperBowlWeb.Controllers
{
    public class ParisController : BaseApiController
    {
        private readonly SuperBowlWebContext _context;

        public ParisController(SuperBowlWebContext context)
        {
            _context = context;
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
        [HttpGet("bymatch/{matchId}")]
        public async Task<IActionResult> getByMatchId(int matchId)
        {
            if (_context.Pari.Any())
            {
                var pariUser = await _context.Pari.Where(x => x.MatchId == matchId).Include(x => x.EquipeMise).Include(x=>x.Jeu).ToListAsync();
                return Ok(pariUser);
            }
            return NotFound("Pas encore de paris enregistre");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pari pari)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pari);
                await _context.SaveChangesAsync();
                return Ok(1);
            }

            return NotFound(1);
        }

        // GET: Paris/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Pari == null)
        //    {
        //        return NotFound();
        //    }

        //    var pari = await _context.Pari
        //        .Include(p => p.EquipeMise)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (pari == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(pari);
        //}


        // POST: Paris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        //// GET: Paris/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Pari == null)
        //    {
        //        return NotFound();
        //    }

        //    var pari = await _context.Pari.FindAsync(id);
        //    if (pari == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["EquipeId"] = new SelectList(_context.Equipe, "Id", "Id", pari.EquipeId);
        //    return View(pari);
        //}

        //// POST: Paris/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,MatchId,UserId,MontantMise,EquipeId")] Pari pari)
        //{
        //    if (id != pari.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(pari);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PariExists(pari.Id))
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
        //    ViewData["EquipeId"] = new SelectList(_context.Equipe, "Id", "Id", pari.EquipeId);
        //    return View(pari);
        //}

        //// GET: Paris/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Pari == null)
        //    {
        //        return NotFound();
        //    }

        //    var pari = await _context.Pari
        //        .Include(p => p.EquipeMise)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (pari == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(pari);
        //}

        //// POST: Paris/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Pari == null)
        //    {
        //        return Problem("Entity set 'SuperBowlWebContext.Pari'  is null.");
        //    }
        //    var pari = await _context.Pari.FindAsync(id);
        //    if (pari != null)
        //    {
        //        _context.Pari.Remove(pari);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool PariExists(int id)
        {
          return (_context.Pari?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
