using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCube.Models;
using ApiCube.Models.BuisnessObjects;

namespace ApiCube.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyAllowSpecificOrigins")]
    [ApiController]
    public class ConsultersController : ControllerBase
    {
        private readonly AppContexte _context;

        public ConsultersController(AppContexte context)
        {
            _context = context;
        }

        // GET: api/Consulters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consulter>>> GetConsulters()
        {
            return await _context.Consulters.ToListAsync();
        }

        // GET: api/Consulters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consulter>> GetConsulter(int id)
        {
            var consulter = await _context.Consulters.FindAsync(id);

            if (consulter == null)
            {
                return NotFound();
            }

            return consulter;
        }

        // PUT: api/Consulters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsulter(int id, Consulter consulter)
        {
            if (id != consulter.ConsulterId)
            {
                return BadRequest();
            }

            _context.Entry(consulter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsulterExists(id))
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

        // POST: api/Consulters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Consulter>> PostConsulter(Consulter consulter)
        {
            _context.Consulters.Add(consulter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsulter", new { id = consulter.ConsulterId }, consulter);
        }

        // DELETE: api/Consulters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsulter(int id)
        {
            var consulter = await _context.Consulters.FindAsync(id);
            if (consulter == null)
            {
                return NotFound();
            }

            _context.Consulters.Remove(consulter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsulterExists(int id)
        {
            return _context.Consulters.Any(e => e.ConsulterId == id);
        }
    }
}
