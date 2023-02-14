using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCube.Models.BuisnessObjects
{
    public class Utilisateur
    {
        [Key]
        public int UtilisateurId { get; set; }
        [MaxLength(150)]
        public string? Nom { get; set; }
        [MaxLength(150)]
        public string? Prenom { get; set; }
        [MaxLength(50)]
        public string? MotDePasse { get; set; }
        [MaxLength(15)]
        public string? Telephone { get; set; }
        [MaxLength(150)]
        public string? Email { get;set; }
        public bool UtilisateurActif { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DerniereConnexion { get; set; }
        public string? Role { get; set; }

        public Adresse? Adresse { get; set; }

        [NotMapped]
        public virtual ICollection<ModererCom> modererComs { get; set; }
        [NotMapped]
        public virtual ICollection<ModererRes> modererRess{ get; set; }
    }
}
