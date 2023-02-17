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
    public class ModererComsController : ControllerBase
    {
        private readonly AppContexte _context;

        public ModererComsController(AppContexte context)
        {
            _context = context;
        }

        // GET: api/ModererComs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModererCom>>> GetModererComs()
        {
            return await _context.ModererComs.ToListAsync();
        }

        // GET: api/ModererComs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModererCom>> GetModererCom(int id)
        {
            var modererCom = await _context.ModererComs.FindAsync(id);

            if (modererCom == null)
            {
                return NotFound();
            }

            return modererCom;
        }

        // PUT: api/ModererComs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModererCom(int id, ModererCom modererCom)
        {
            if (id != modererCom.ModererComId)
            {
                return BadRequest();
            }

            _context.Entry(modererCom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModererComExists(id))
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

        // POST: api/ModererComs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModererCom>> PostModererCom(ModererCom modererCom)
        {
            _context.ModererComs.Add(modererCom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModererCom", new { id = modererCom.ModererComId }, modererCom);
        }

        // DELETE: api/ModererComs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModererCom(int id)
        {
            var modererCom = await _context.ModererComs.FindAsync(id);
            if (modererCom == null)
            {
                return NotFound();
            }

            _context.ModererComs.Remove(modererCom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModererComExists(int id)
        {
            return _context.ModererComs.Any(e => e.ModererComId == id);
        }
    }
}
