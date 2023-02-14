using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiCube.Models.BuisnessObjects
{
    [Keyless]
    public class Rechercher
    {
        [MaxLength(255)]
        [Required]
        public string? RechercheLibelle { get; set; }

        public DateTime? RechercheDate { get;set; }

        public Ressource? Ressource { get; set; }
        public Utilisateur? Utilisateur { get;set; }
    }
}
