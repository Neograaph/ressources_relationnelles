
﻿using ApiCube.Models;
using ApiCube.Models.BuisnessObjects;
using ApiCube.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
namespace ApiCube.Controllers
{
    [ApiController]
    [EnableCors("MyAllowSpecificOrigins")]
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
            return await _context.Ressources
                .Include(r => r.TypeRessource) // Charger les données associées du type de ressource
                .Include(r => r.Categorie)
                .Include(r => r.Utilisateur)
                .Include(r => r.Document)// Charger les données associées de la catégorie
                .ToListAsync();
        }

        // GET: api/Ressources/utilisateur/2
        [HttpGet("utilisateur/{utilisateurId}")]
        public async Task<ActionResult<IEnumerable<Ressource>>> GetRessources(int utilisateurId)
        {
            return await _context.Ressources.Where(r => r.UtilisateurId == utilisateurId).ToListAsync();
        }

        // GET: api/Ressources/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ressource>> GetRessource(int id)
        {
            var ressource = await _context.Ressources
                .Include(r => r.TypeRessource)
                .Include(r => r.Categorie)
                .Include(r => r.Utilisateur)
                .Include(r => r.Document)
                .FirstOrDefaultAsync(r => r.RessourceId == id);

            if (ressource == null)
            {
                return NotFound();
            }

            return ressource;
        }

        [HttpPost("publier")]
        public async Task<ActionResult<Ressource>> PostRessource([FromForm] PublierRessource postRessource)
        {
            // Vérifier si le fichier est présent dans la requête
            if (postRessource.Fichier != null && postRessource.Fichier.Length > 0)
            {
                // Obtenir le chemin absolu du répertoire de destination
                var directoryPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "Front", "src", "assets", "documents"));

                // Vérifier si le répertoire existe, sinon le créer
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Lire le flux du document et effectuer les opérations nécessaires
                var randomNumber = new Random().Next(1000, 9999); // Générer un numéro aléatoire entre 1000 et 9999
                var fileName = $"{randomNumber}_{Path.GetFileName(postRessource.Fichier.FileName)}";

                var filePath = Path.Combine(directoryPath, fileName); // Chemin complet du fichier

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await postRessource.Fichier.CopyToAsync(fileStream);
                }

                // Créer un objet Document avec les informations du document
                var document = new Document
                {
                    Poids = (int)postRessource.Fichier.Length,
                    Extension = Path.GetExtension(postRessource.Fichier.FileName),
                    Chemin = fileName
                };
                _context.Documents.Add(document);
                // Créer un objet Ressource avec les informations de la requête
                var ressource = new Ressource
                {
                    DateCreation = DateTime.Now,
                    Valider = true,
                    VisibiliteLibelle = "Publique",
                    CategorieId = postRessource.CategorieId,
                    TypeRessourceId = postRessource.TypeRessourceId,
                    Titre = postRessource.Titre,
                    Contenu = postRessource.Contenu,
                    Document = document,
                    UtilisateurId = postRessource.UtilisateurId
                };

                // Ajouter la ressource à la base de données
                _context.Ressources.Add(ressource);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetRessource", new { id = ressource.RessourceId }, ressource);
            }

            // Retourner une erreur si aucun fichier n'a été fourni
            return BadRequest("Aucun fichier n'a été fourni.");
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
