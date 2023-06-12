using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace ApiCube.Models.BuisnessObjects
{
    public class Aimer
    {

        [Key]
        public int AimerId { get; set; }
        [Required]
        public int RessourceId   { get; set; }
        public Ressource? Ressource { get; set; }
        [Required]
        public DateTime DateAimer { get; set; }

        public int UtilisateurId { get; set; }
        public Utilisateur? Utilisateur { get; set; }
    }
}
