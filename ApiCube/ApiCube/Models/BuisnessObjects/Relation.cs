using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiCube.Models.BuisnessObjects
{
    [Keyless]
    public class Relation
    {
        [Required]
        public Utilisateur? Utilisateur { get; set; }
        [Required]
        public Utilisateur? UtilisateurRelation { get; set; }
        [MaxLength(50)]
        [Required]
        public string? Libelle { get; set; }
        [Required]
        [MaxLength(150)]
        public string? Type { get; set; }
    }
}
