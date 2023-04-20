using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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

namespace ApiCube.Controllers
{
    [Route("api/[controller]")]
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

        // POST: api/Utilisateurs/authenticate
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthentificationRequest request)
        {
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
                    new Claim(ClaimTypes.Name, utilisateur.UtilisateurId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }

        // POST: api/Utilisateurs
        [HttpPost]
        public async Task<ActionResult<Utilisateur>> PostUtilisateur(Utilisateur utilisateur)
        {
            if (_context.Utilisateurs.Any(u => u.Email == utilisateur.Email))
            {
                return BadRequest("Email déjà utilisé.");
            }

            utilisateur.DateCreation = DateTime.Now;
            utilisateur.MotDePasse = BCrypt.Net.BCrypt.HashPassword(utilisateur.MotDePasse);

            _context.Utilisateurs.Add(utilisateur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilisateur", new { id = utilisateur.UtilisateurId }, utilisateur);
        }

        // GET: api/Utilisateurs/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Utilisateur>> GetUtilisateur(int id)
        {
            var utilisateur = await _context.Utilisateurs.FindAsync(id);

            if (utilisateur == null)
            {
                return NotFound();
            }

            return utilisateur;
        }
        // PUT: api/Utilisateurs/5
        [HttpPut("{id}")]
        [Authorize]
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
        [Authorize(Roles = "admin")]
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
