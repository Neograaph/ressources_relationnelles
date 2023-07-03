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
    public class AimersController : ControllerBase
    {
        private readonly AppContexte _context;

        public AimersController(AppContexte context)
        {
            _context = context;
        }

        // GET: api/Aimers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aimer>>> GetAimers()
        {
            return await _context.Aimers.ToListAsync();
        }

        // GET: api/Aimers/Utilisateur/{id}
        [HttpGet("Utilisateur/{id}")]
        public async Task<ActionResult<IEnumerable<Aimer>>> GetAimersByUtilisateur(int id)
        {
            var aimers = await _context.Aimers.Where(a => a.UtilisateurId == id).Include(r => r.Ressource).ToListAsync();

            return aimers;
        }

        // GET: api/Aimers/CheckExists
        [HttpGet("CheckExists")]
        public async Task<ActionResult<bool>> CheckAimerExists(int utilisateurId, int ressourceId)
        {
            var exists = await _context.Aimers.AnyAsync(a => a.UtilisateurId == utilisateurId && a.RessourceId == ressourceId);
            return exists;
        }



        // GET: api/Aimers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aimer>> GetAimer(int id)
        {
            var aimer = await _context.Aimers.FindAsync(id);

            if (aimer == null)
            {
                return NotFound();
            }

            return aimer;
        }

        // PUT: api/Aimers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAimer(int id, Aimer aimer)
        {
            if (id != aimer.AimerId)
            {
                return BadRequest();
            }

            _context.Entry(aimer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AimerExists(id))
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

        // POST: api/Aimers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aimer>> PostAimer(Aimer aimer)
        {
            _context.Aimers.Add(aimer);
            await _context.SaveChangesAsync();

            // Inclure la ressource associée
            await _context.Entry(aimer)
                .Reference(a => a.Ressource)
                .LoadAsync();

            return CreatedAtAction("GetAimer", new { id = aimer.AimerId }, aimer);
        }


        // DELETE: api/Aimers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAimer(int id)
        {
            var aimer = await _context.Aimers.FirstOrDefaultAsync(a => a.RessourceId == id);
            if (aimer == null)
            {
                return NotFound();
            }
            _context.Aimers.Remove(aimer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AimerExists(int id)
        {
            return _context.Aimers.Any(e => e.AimerId == id);
        }
    }
}
