using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.ExamenC.Entidades;

namespace App.ExamenC.MVCV1.Controllers
{
    public class PonentesController : Controller
    {
        private readonly DbContext _context;

        public PonentesController(DbContext context)
        {
            _context = context;
        }

        // GET: Ponentes
        public async Task<IActionResult> Index()
        {
            var dbContext = _context.Ponente.Include(p => p.Conferencia);
            return View(await dbContext.ToListAsync());
        }

        // GET: Ponentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ponente = await _context.Ponente
                .Include(p => p.Conferencia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ponente == null)
            {
                return NotFound();
            }

            return View(ponente);
        }

        // GET: Ponentes/Create
        public IActionResult Create()
        {
            ViewData["ConferenciaId"] = new SelectList(_context.Conferencia, "Id", "Lugar");
            return View();
        }

        // POST: Ponentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Tema,ConferenciaId")] Ponente ponente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ponente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConferenciaId"] = new SelectList(_context.Conferencia, "Id", "Lugar", ponente.ConferenciaId);
            return View(ponente);
        }

        // GET: Ponentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ponente = await _context.Ponente.FindAsync(id);
            if (ponente == null)
            {
                return NotFound();
            }
            ViewData["ConferenciaId"] = new SelectList(_context.Conferencia, "Id", "Lugar", ponente.ConferenciaId);
            return View(ponente);
        }

        // POST: Ponentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Tema,ConferenciaId")] Ponente ponente)
        {
            if (id != ponente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ponente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PonenteExists(ponente.Id))
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
            ViewData["ConferenciaId"] = new SelectList(_context.Conferencia, "Id", "Lugar", ponente.ConferenciaId);
            return View(ponente);
        }

        // GET: Ponentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ponente = await _context.Ponente
                .Include(p => p.Conferencia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ponente == null)
            {
                return NotFound();
            }

            return View(ponente);
        }

        // POST: Ponentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ponente = await _context.Ponente.FindAsync(id);
            if (ponente != null)
            {
                _context.Ponente.Remove(ponente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PonenteExists(int id)
        {
            return _context.Ponente.Any(e => e.Id == id);
        }
    }
}
