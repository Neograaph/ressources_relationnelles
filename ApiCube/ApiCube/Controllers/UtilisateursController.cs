using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiCube.Models;
using ApiCube.Models.BuisnessObjects;
using ApiCube.Models.DTO;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Cors;

namespace ApiCube.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyAllowSpecificOrigins")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AppContexte _context;

        public UtilisateursController(IConfiguration config, AppContexte context)
        {
            _config = config;
            _context = context;
        }
        // GET: api/Utilisateurs/5

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetUtilisateur()
        {
            return await _context.Utilisateurs.ToListAsync();
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthentificationRequest request)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "http://cube-cesi.ddns.net:4200");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
            Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");
            var utilisateur = _context.Utilisateurs.SingleOrDefault(u => u.Email == request.Email);

            if (utilisateur == null)
            {
                return BadRequest("Email ou mot de passe incorrect.");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.MotDePasse, utilisateur.MotDePasse))
            {
                return BadRequest("Email ou mot de passe incorrect.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Secret").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, utilisateur.Prenom + " " + utilisateur.Nom),
                new Claim(ClaimTypes.Role, utilisateur.Role),
                new Claim("UtilisateurId", utilisateur.UtilisateurId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }

        // OPTIONS: api/Utilisateurs/authenticate
        [HttpOptions("authenticate")]
        public IActionResult OptionsAuthenticate()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "http://cube-cesi.ddns.net:4200");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
            Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");

            return Ok();
        }



        // POST: api/Utilisateurs
        [HttpPost]
        public async Task<ActionResult<Utilisateur>> PostUtilisateur(AjoutUtilisateur utilisateur)
        {
            if (_context.Utilisateurs.Any(u => u.Email == utilisateur.Email))
            {
                return BadRequest("Email déjà utilisé.");
            }
            var nouvelUtilisateur = new Utilisateur
            {
                Email = utilisateur.Email,
                MotDePasse = BCrypt.Net.BCrypt.HashPassword(utilisateur.MotDePasse),
                DateNaissance= utilisateur.DateNaissance,
                Prenom = utilisateur.Prenom,
                Nom = utilisateur.Nom,
                Telephone = utilisateur.Telephone,
                Role = "Citoyen",
                DateCreation = DateTime.Now
            };


            //utilisateur.DateCreation = DateTime.Now;
            //utilisateur.MotDePasse = BCrypt.Net.BCrypt.HashPassword(utilisateur.MotDePasse);

            _context.Utilisateurs.Add(nouvelUtilisateur);
            await _context.SaveChangesAsync();
            // Appeler la fonction Authenticate pour générer le token
            var authRequest = new AuthentificationRequest
            {
                Email = nouvelUtilisateur.Email,
                MotDePasse = utilisateur.MotDePasse
            };

            var authenticationResult = Authenticate(authRequest) as ObjectResult;

            if (authenticationResult?.StatusCode == (int)HttpStatusCode.OK)
            {
                var tokenResponse = authenticationResult.Value as dynamic;
                var token = tokenResponse.Token;

                // Faire quelque chose avec le token, par exemple le retourner dans la réponse
                return CreatedAtAction("GetUtilisateur", new { id = nouvelUtilisateur.UtilisateurId }, new { Token = token });
            }
            else
            {
                // Gérer les erreurs d'authentification
                return BadRequest("Erreur lors de l'authentification.");
            }
        }

        // GET: api/Utilisateurs/5
        [HttpGet("{id}")]
       // [Authorize]
        public async Task<ActionResult<Utilisateur>> GetUtilisateur(int id)
        {
            var utilisateur = await _context.Utilisateurs.FindAsync(id);

            if (utilisateur == null)
            {
                return NotFound();
            }

            return utilisateur;
        }
        [HttpGet("{userId}/aimers")]
        public async Task<ActionResult<IEnumerable<Aimer>>> GetAimersByUserId(int userId)
        {
            var aimers = await _context.Aimers
                .Where(a => a.UtilisateurId == userId)
                .ToListAsync();

            if (aimers == null)
            {
                return NotFound();
            }

            return aimers;
        }
        // PUT: api/Utilisateurs/5
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> PutUtilisateur(int id, Utilisateur utilisateur)
        {
            if (id != utilisateur.UtilisateurId)
            {
                return BadRequest();
            }

            var existingUtilisateur = await _context.Utilisateurs.FindAsync(id);
            if (existingUtilisateur == null)
            {
                return NotFound();
            }

            existingUtilisateur.Nom = utilisateur.Nom;
            existingUtilisateur.Prenom = utilisateur.Prenom;
            existingUtilisateur.Telephone = utilisateur.Telephone;
            existingUtilisateur.Email = utilisateur.Email;
            existingUtilisateur.Role = utilisateur.Role;
            existingUtilisateur.UtilisateurActif = utilisateur.UtilisateurActif;
            existingUtilisateur.Adresse = utilisateur.Adresse;

            _context.Entry(existingUtilisateur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilisateurExists(id))
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

        // DELETE: api/Utilisateurs/5
        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<Utilisateur>> DeleteUtilisateur(int id)
        {
            var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            _context.Utilisateurs.Remove(utilisateur);
            await _context.SaveChangesAsync();

            return utilisateur;
        }

        private bool UtilisateurExists(int id)
        {
            return _context.Utilisateurs.Any(e => e.UtilisateurId == id);
        }

        // OPTIONS: api/Utilisateurs/
        //[HttpOptions]
        //public IActionResult Options()
        //{
        //    Response.Headers.Add("Access-Control-Allow-Origin", "http://cube-cesi.ddns.net:4200");
        //    Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
        //    Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");

        //    return Ok();
        //}

    }
}

//// PUT: api/Utilisateurs/5
//[HttpPut("{id}")]
//[Authorize]
//public async Task<IActionResult> PutUtilisateur(int id, Utilisateur utilisateur)
//{
//    if (id != utilisateur.UtilisateurId)
//    {
//        return BadRequest();
//    }

//    _context.Entry(utilisateur).State = EntityState.Modified;

//    try
//    {
//        await _context.SaveChangesAsync();
//    }
//    catch (DbUpdateConcurrencyException)
//    {
//        if (!UtilisateurExists(id
