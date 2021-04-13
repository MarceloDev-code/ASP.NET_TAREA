using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using negamed.Models;

namespace negamed.Controllers
{
    [Route("api/negamed")]
    [ApiController]
    public class negamedController : ControllerBase
    {
        private readonly negamedContext _context;

        public negamedController(negamedContext context)
        {
            _context = context;
        }

        // GET: api/negamed
        [HttpGet]
        public async Task<ActionResult<IEnumerable<paciente>>> Getpacientes()
        {
            return await _context.pacientes.ToListAsync();
        }

        // GET: api/negamed/5
        [HttpGet("{id}")]
        public async Task<ActionResult<paciente>> Getpaciente(long id)
        {
            var paciente = await _context.pacientes.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return paciente;
        }

        // PUT: api/negamed/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpaciente(long id, paciente paciente)
        {
            if (id != paciente.Id)
            {
                return BadRequest();
            }

            _context.Entry(paciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pacienteExists(id))
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

        // POST: api/negamed
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<paciente>> Postpaciente(paciente paciente)
        {
            _context.pacientes.Add(paciente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpaciente", new { id = paciente.Id }, paciente);
        }

        // DELETE: api/negamed/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<paciente>> Deletepaciente(long id)
        {
            var paciente = await _context.pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            _context.pacientes.Remove(paciente);
            await _context.SaveChangesAsync();

            return paciente;
        }

        private bool pacienteExists(long id)
        {
            return _context.pacientes.Any(e => e.Id == id);
        }
    }
}
