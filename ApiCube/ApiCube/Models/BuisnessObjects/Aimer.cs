using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiCube.Models.BuisnessObjects
{
    public class Aimer
    {

        [Key]
        public int AimerId { get; set; }
        [Required]
        public Ressource? Ressource { get; set; }
        [Required]
        public DateTime DateAimer { get; set; }
    }
}
