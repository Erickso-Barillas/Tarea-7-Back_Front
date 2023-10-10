using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tarea_net7.Models;

namespace tarea_net7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoSangresController : ControllerBase
    {
        private readonly EscuelaDbContext _context;

        public TipoSangresController(EscuelaDbContext context)
        {
            _context = context;
        }

        // GET: 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoSangre>>> GetTiposSangre()
        {
          if (_context.TiposSangre == null)
          {
              return NotFound();
          }
            return await _context.TiposSangre.ToListAsync();
        }

        // GET: 
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoSangre>> GetTipoSangre(int id)
        {
          if (_context.TiposSangre == null)
          {
              return NotFound();
          }
            var tipo_Sangre = await _context.TiposSangre.FindAsync(id);

            if (tipo_Sangre == null)
            {
                return NotFound();
            }

            return tipo_Sangre;
        }

        // PUT: 

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoSangre(int id, TipoSangre tipo_Sangre)
        {
            if (id != tipo_Sangre.IdTipoSangre)
            {
                return BadRequest();
            }

            _context.Entry(tipo_Sangre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoSangreExists(id))
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

        // POST: 

        [HttpPost]
        public async Task<ActionResult<TipoSangre>> PostTipoSangre(TipoSangre tipo_Sangre)
        {
          if (_context.TiposSangre == null)
          {
              return Problem("Entity set 'EscuelaDbContext.TiposSangre'  is null.");
          }
            _context.TiposSangre.Add(tipo_Sangre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoSangre", new { id = tipo_Sangre.IdTipoSangre }, tipo_Sangre);
        }

        // DELETE: 

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoSangre(int id)
        {
            if (_context.TiposSangre == null)
            {
                return NotFound();
            }
            var tipo_Sangre = await _context.TiposSangre.FindAsync(id);
            if (tipo_Sangre == null)
            {
                return NotFound();
            }

            _context.TiposSangre.Remove(tipo_Sangre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoSangreExists(int id)
        {
            return (_context.TiposSangre?.Any(e => e.Id_Tipo_Sangre == id)).GetValueOrDefault();
        }
    }
}
