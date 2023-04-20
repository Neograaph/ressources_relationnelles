
using System.ComponentModel.DataAnnotations;

namespace ApiCube.Models.BuisnessObjects
{
    public class Adresse
    {
        [Key]
        public int AdresseId { get; set; }
        public int AdresseNum { get; set; }
        [MaxLength(150)]
        [Required]
        public string? Rue { get; set; }
        [MaxLength(5)]
        [Required]
        public string? Cp { get; set; }
        [MaxLength(150)]
        [Required]
        public string? Ville { get; set; }
    }
}