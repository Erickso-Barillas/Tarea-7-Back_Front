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
    public class EstudiantesController : ControllerBase
    {
        private readonly EscuelaDbContext _context;

        public EstudiantesController(EscuelaDbContext context)
        {
            _context = context;
        }

        // GET: 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetEstudiantes()
        {
            if (_context.Estudiantes == null)
            {
                return NotFound();
            }
            var estudiantes = await _context.Estudiantes
                .Select(e => new
                {
                    e.Id_Estudiante,
                    e.Carnet,
                    e.Nombres,
                    e.Apellidos,
                    e.Direccion,
                    e.Telefono,
                    e.Correo_Electronico,
                    Tipo_Sangre = e.Tipo_Sangre.Sangre,
                    e.Fecha_Nacimiento
                })
                .ToListAsync();
            return estudiantes;
        }

        // GET: 

        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
        {
          if (_context.Estudiantes == null)
          {
              return NotFound();
          }
            var estudiante = await _context.Estudiantes.FindAsync(id);

            if (estudiante == null)
            {
                return NotFound();
            }

            return estudiante;
        }

        // PUT: 
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiante(int id, Estudiante estudiante)
        {
            if (id != estudiante.IdEstudiante)
            {
                return BadRequest();
            }

            _context.Entry(estudiante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(id))
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
        public async Task<ActionResult<Estudiante>> PostEstudiante(Estudiante estudiante)
        {
          if (_context.Estudiantes == null)
          {
              return Problem("Entity set 'EscuelaDbContext.Estudiantes'  is null.");
          }
            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstudiante", new { id = estudiante.Id_Estudiante }, estudiante);
        }

        // DELETE: 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            if (_context.Estudiantes == null)
            {
                return NotFound();
            }
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstudianteExists(int id)
        {
            return (_context.Estudiantes?.Any(e => e.Id_Estudiante == id)).GetValueOrDefault();
        }
    }
}
