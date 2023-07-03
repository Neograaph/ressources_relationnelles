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
    public class ModererResController : ControllerBase
    {
        private readonly AppContexte _context;

        public ModererResController(AppContexte context)
        {
            _context = context;
        }

        // GET: api/ModererRes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModererRes>>> GetModererRess()
        {
            return await _context.ModererRess.ToListAsync();
        }

        // GET: api/ModererRes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModererRes>> GetModererRes(int id)
        {
            var modererRes = await _context.ModererRess.FindAsync(id);

            if (modererRes == null)
            {
                return NotFound();
            }

            return modererRes;
        }

        // PUT: api/ModererRes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModererRes(int id, ModererRes modererRes)
        {
            if (id != modererRes.ModererResId)
            {
                return BadRequest();
            }

            _context.Entry(modererRes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModererResExists(id))
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

        // POST: api/ModererRes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModererRes>> PostModererRes(ModererRes modererRes)
        {
            _context.ModererRess.Add(modererRes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModererRes", new { id = modererRes.ModererResId }, modererRes);
        }

        // DELETE: api/ModererRes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModererRes(int id)
        {
            var modererRes = await _context.ModererRess.FindAsync(id);
            if (modererRes == null)
            {
                return NotFound();
            }

            _context.ModererRess.Remove(modererRes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModererResExists(int id)
        {
            return _context.ModererRess.Any(e => e.ModererResId == id);
        }
    }
}
