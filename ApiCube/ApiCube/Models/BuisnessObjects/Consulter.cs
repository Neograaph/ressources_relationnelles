using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiCube.Models.BuisnessObjects
{
    public class Consulter
    {

        [Key]
        public int ConsulterId { get; set; }
        [Required]
        public int RessourceId { get; set; }
        public Ressource? Ressource { get; set; }

        public int UtilisateurId { get; set; }
        public Utilisateur? Utilisateur { get; set; }


    }
}
