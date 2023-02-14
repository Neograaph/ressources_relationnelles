using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiCube.Models.BuisnessObjects
{
    public class Consulter
    {

        [Key]
        public int ConsulterId { get; set; }
        [Required]
        public Ressource? Ressource { get; set; }
       
    }
}
