using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperBowlWeb.Data;
using SuperBowlWeb.Models;

namespace SuperBowlWeb.Controllers
{
    public class JoueursController : Controller
    {
        private readonly SuperBowlWebContext _context;

        public JoueursController(SuperBowlWebContext context)
        {
            _context = context;
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

            var joueur = await _context.Joueur
                .Include(j => j.Equipe)
                .Include(j => j.Pays)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (joueur == null)
            {
                return NotFound();
            }

            return View(joueur);
        }

        // GET: Joueurs/Create
        public IActionResult Create()
        {
            ViewData["EquipeId"] = new SelectList(_context.Equipe, "Id", "Id");
            ViewData["PaysId"] = new SelectList(_context.Pays, "Id", "Id");
            return View();
        }

        // POST: Joueurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Numero,EquipeId,PaysId")] Joueur joueur)
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

        // GET: Joueurs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Joueur == null)
            {
                return NotFound();
            }

            var joueur = await _context.Joueur.FindAsync(id);
            if (joueur == null)
            {
                return NotFound();
            }
            ViewData["EquipeId"] = new SelectList(_context.Equipe, "Id", "Id", joueur.EquipeId);
            ViewData["PaysId"] = new SelectList(_context.Pays, "Id", "Id", joueur.PaysId);
            return View(joueur);
        }

        // POST: Joueurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nom,Prenom,Numero,EquipeId,PaysId")] Joueur joueur)
        {
            if (id != joueur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(joueur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JoueurExists(joueur.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipeId"] = new SelectList(_context.Equipe, "Id", "Id", joueur.EquipeId);
            ViewData["PaysId"] = new SelectList(_context.Pays, "Id", "Id", joueur.PaysId);
            return View(joueur);
        }

        // GET: Joueurs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Joueur == null)
            {
                return NotFound();
            }

            var joueur = await _context.Joueur
                .Include(j => j.Equipe)
                .Include(j => j.Pays)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (joueur == null)
            {
                return NotFound();
            }

            return View(joueur);
        }

        // POST: Joueurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Joueur == null)
            {
                return Problem("Entity set 'SuperBowlWebContext.Joueur'  is null.");
            }
            var joueur = await _context.Joueur.FindAsync(id);
            if (joueur != null)
            {
                _context.Joueur.Remove(joueur);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JoueurExists(long id)
        {
          return (_context.Joueur?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
