using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.ExamenC.Entidades;

namespace App.ExamenC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferenciasController : ControllerBase
    {
        private readonly DBContext _context;

        public ConferenciasController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Conferencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conferencia>>> GetConferencia()
        {
            var conferencia = await _context.Conferencia
            .Include(e => e.Ponentes)
            .ToListAsync();

            return conferencia;
        }

        // GET: api/Conferencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conferencia>> GetConferencia(int id)
        {
            var conferencia = await _context.Conferencia
            .Include(e => e.Ponentes).
            Where(e => e.Id == id).
            FirstOrDefaultAsync();


            if (conferencia == null)
            {
                return NotFound();
            }

            return conferencia;
        }

        // PUT: api/Conferencias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConferencia(int id, Conferencia conferencia)
        {
            if (id != conferencia.Id)
            {
                return BadRequest();
            }

            _context.Entry(conferencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConferenciaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Conferencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Conferencia>> PostConferencia(Conferencia conferencia)
        {
            _context.Conferencia.Add(conferencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConferencia", new { id = conferencia.Id }, conferencia);
        }

        // DELETE: api/Conferencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConferencia(int id)
        {
            var conferencia = await _context.Conferencia.FindAsync(id);
            if (conferencia == null)
            {
                return NotFound();
            }

            _context.Conferencia.Remove(conferencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConferenciaExists(int id)
        {
            return _context.Conferencia.Any(e => e.Id == id);
        }
    }
}
