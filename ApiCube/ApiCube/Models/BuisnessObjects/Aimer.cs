using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiCube.Models.BuisnessObjects
{
    [Keyless]
    public class Aimer
    {
        [Required]
        public Utilisateur? Utilisateur { get; set; }
        [Required]
        public Ressource? Ressource { get; set; }
        [Required]
        public DateTime DateAimer { get; set; }
    }
}
