using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [Required]
        [Range(1, 4, ErrorMessage = "Invalid role ID.")]
        public int Role { get; set; }

        public Adresse Adresse { get; set; }


        public ICollection<Aimer>? Aimes { get; set; }
        public ICollection<Ressource>? Ressources { get; set; }
        public virtual ICollection<Relation>? Relations { get; set; }
    }
}
