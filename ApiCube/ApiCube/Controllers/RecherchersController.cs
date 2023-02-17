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
    [ApiController]
    public class RecherchersController : ControllerBase
    {
        private readonly AppContexte _context;

        public RecherchersController(AppContexte context)
        {
            _context = context;
        }

        // GET: api/Recherchers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rechercher>>> GetRecherchers()
        {
            return await _context.Recherchers.ToListAsync();
        }

        // GET: api/Recherchers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rechercher>> GetRechercher(int id)
        {
            var rechercher = await _context.Recherchers.FindAsync(id);

            if (rechercher == null)
            {
                return NotFound();
            }

            return rechercher;
        }

        // PUT: api/Recherchers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRechercher(int id, Rechercher rechercher)
        {
            if (id != rechercher.RechercherId)
            {
                return BadRequest();
            }

            _context.Entry(rechercher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RechercherExists(id))
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

        // POST: api/Recherchers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rechercher>> PostRechercher(Rechercher rechercher)
        {
            _context.Recherchers.Add(rechercher);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRechercher", new { id = rechercher.RechercherId }, rechercher);
        }

        // DELETE: api/Recherchers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRechercher(int id)
        {
            var rechercher = await _context.Recherchers.FindAsync(id);
            if (rechercher == null)
            {
                return NotFound();
            }

            _context.Recherchers.Remove(rechercher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RechercherExists(int id)
        {
            return _context.Recherchers.Any(e => e.RechercherId == id);
        }
    }
}
