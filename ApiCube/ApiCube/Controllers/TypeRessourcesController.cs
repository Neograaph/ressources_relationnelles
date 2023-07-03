using ApiCube.Models.BuisnessObjects;
using ApiCube.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
namespace ApiCube.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyAllowSpecificOrigins")] 
    [ApiController]
    public class TypeRessourcesController : ControllerBase
    {
        private readonly AppContexte _context;

        public TypeRessourcesController(AppContexte context)
        {
            _context = context;
        }

        // GET: api/typeressources
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeRessource>>> GetTypeRessources()
        {
            var typeRessources = await _context.TypeRessources.ToListAsync();
            return Ok(typeRessources);
        }

        // GET: api/typeressources/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeRessource>> GetTypeRessource(int id)
        {
            var typeRessource = await _context.TypeRessources.FindAsync(id);

            if (typeRessource == null)
            {
                return NotFound();
            }

            return Ok(typeRessource);
        }

        // POST: api/typeressources
        [HttpPost]
        public async Task<ActionResult<TypeRessource>> CreateTypeRessource(TypeRessource typeRessource)
        {
            _context.TypeRessources.Add(typeRessource);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTypeRessource), new { id = typeRessource.TypeRessourceId }, typeRessource);
        }

        // PUT: api/typeressources/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTypeRessource(int id, TypeRessource typeRessource)
        {
            if (id != typeRessource.TypeRessourceId)
            {
                return BadRequest();
            }

            _context.Entry(typeRessource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeRessourceExists(id))
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

        // DELETE: api/typeressources/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeRessource(int id)
        {
            var typeRessource = await _context.TypeRessources.FindAsync(id);
            if (typeRessource == null)
            {
                return NotFound();
            }

            _context.TypeRessources.Remove(typeRessource);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeRessourceExists(int id)
        {
            return _context.TypeRessources.Any(tr => tr.TypeRessourceId == id);
        }
    }
}
