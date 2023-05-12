using ApiCube.Models.BuisnessObjects;
using System.ComponentModel.DataAnnotations;

namespace ApiCube.Models.DTO
{
    public class AjoutUtilisateur
    {
        [MaxLength(150)]
        public string Nom { get; set; }
        [MaxLength(150)]
        public string Prenom { get; set; }
        public string MotDePasse { get; set; }
        [MaxLength(15)]
        public string? Telephone { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
    }
}
