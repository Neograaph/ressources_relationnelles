using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Text.Json.Serialization;

namespace ApiCube.Models.BuisnessObjects
{
    public class Aimer
    {
        [Key]
        public int AimerId { get; set; }

        [Required]
        public int RessourceId { get; set; }
        [NotMapped]
        public Ressource? Ressource { get; set; } // Supprimer l'attribut 

        [Required]
        public DateTime DateAimer { get; set; }

        public int UtilisateurId { get; set; }

        [JsonIgnore]
        [NotMapped]
        public Utilisateur? Utilisateur { get; set; }
    }

}
