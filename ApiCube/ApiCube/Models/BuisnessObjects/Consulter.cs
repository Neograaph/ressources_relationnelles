using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiCube.Models.BuisnessObjects
{
    [Keyless]
    public class Consulter
    {
        [Required]
        public Utilisateur? Utilisateur { get; set; }
        [Required]
        public Ressource? Ressource { get; set; }
       
    }
}
