using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiCube.Models.BuisnessObjects
{
    public class Aimer
    {

        [Key]
        public int AimerId { get; set; }
        public int RessourceId { get; set; }
        public int UtilisateurId { get; set; }
        public DateTime DateAimer { get; set; }

        public Utilisateur Utilisateur { get; set; }
        public Ressource Ressource { get; set; }
    }
}
