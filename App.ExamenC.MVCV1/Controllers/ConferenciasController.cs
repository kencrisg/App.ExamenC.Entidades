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
    public class ConferenciasController : Controller
    {
        private readonly DbContext _context;

        public ConferenciasController(DbContext context)
        {
            _context = context;
        }

        // GET: Conferencias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Conferencia.ToListAsync());
        }

        // GET: Conferencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conferencia = await _context.Conferencia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conferencia == null)
            {
                return NotFound();
            }

            return View(conferencia);
        }

        // GET: Conferencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conferencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Lugar,FechaInicio")] Conferencia conferencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conferencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conferencia);
        }

        // GET: Conferencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conferencia = await _context.Conferencia.FindAsync(id);
            if (conferencia == null)
            {
                return NotFound();
            }
            return View(conferencia);
        }

        // POST: Conferencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Lugar,FechaInicio")] Conferencia conferencia)
        {
            if (id != conferencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conferencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConferenciaExists(conferencia.Id))
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
            return View(conferencia);
        }

        // GET: Conferencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conferencia = await _context.Conferencia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conferencia == null)
            {
                return NotFound();
            }

            return View(conferencia);
        }

        // POST: Conferencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conferencia = await _context.Conferencia.FindAsync(id);
            if (conferencia != null)
            {
                _context.Conferencia.Remove(conferencia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConferenciaExists(int id)
        {
            return _context.Conferencia.Any(e => e.Id == id);
        }
    }
}
