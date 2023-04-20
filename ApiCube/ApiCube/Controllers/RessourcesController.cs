
﻿using ApiCube.Models;
using ApiCube.Models.BuisnessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCube.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RessourcesController : ControllerBase
    {
        private readonly AppContexte _context;

        public RessourcesController(AppContexte context)
        {
            _context = context;
        }

        // GET: api/Ressources
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ressource>>> GetRessources()
        {
            return await _context.Ressources.ToListAsync();
        }

        // GET: api/Ressources/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ressource>> GetRessource(int id)
        {
            var ressource = await _context.Ressources.FindAsync(id);

            if (ressource == null)
            {
                return NotFound();
            }

            return ressource;
        }


        // POST: api/Ressources
        [HttpPost]
        public async Task<ActionResult<Ressource>> PostRessource(Ressource ressource)
        {
            _context.Ressources.Add(ressource);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRessource), new { id = ressource.RessourceId }, ressource);
        }



        // PUT: api/Ressources/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRessource(int id, Ressource ressource)
        {
            if (id != ressource.RessourceId)
            {
                return BadRequest();
            }

            _context.Entry(ressource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RessourceExists(id))
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

        // POST: api/Ressources
        [HttpPost]
        public async Task<ActionResult<Ressource>> PostRessource(Ressource ressource)
        {
            _context.Ressources.Add(ressource);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRessource), new { id = ressource.RessourceId }, ressource);
        }

        // DELETE: api/Ressources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRessource(int id)
        {
            var ressource = await _context.Ressources.FindAsync(id);
            if (ressource == null)
            {
                return NotFound();
            }

            _context.Ressources.Remove(ressource);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RessourceExists(int id)
        {
            return _context.Ressources.Any(e => e.RessourceId == id);
        }
    }
}
