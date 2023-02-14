using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiCube.Models.BuisnessObjects
{
    public class Rechercher
    {
        [Key]
        public int RechercherId { get; set; }
        [MaxLength(255)]
        [Required]
        public string? RechercheLibelle { get; set; }

        public DateTime? RechercheDate { get;set; }

        public Ressource? Ressource { get; set; }
       
    }
}
