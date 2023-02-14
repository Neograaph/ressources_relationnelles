
using System.ComponentModel.DataAnnotations;

namespace ApiCube.Models.BuisnessObjects
{
    public class Adresse
    {
        [Key]
        public int AdresseId { get; set; }
        [MaxLength(150)]
        [Required]
        public string? Rue { get; set; }
        [MaxLength(5)]
        [Required]
        public int? Cp { get; set; }
        [MaxLength(150)]
        [Required]
        public string? Ville { get; set; }
    }
}