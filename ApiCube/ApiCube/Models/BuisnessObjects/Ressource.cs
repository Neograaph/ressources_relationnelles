using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCube.Models.BuisnessObjects
{
    public class Ressource
    {
        [Key]
        public int RessourceId { get; set; }
        [MaxLength(150)]
        public string? Titre { get; set; }
        public DateTime DateCreation { get; set; }

        [MaxLength(255)]
        public string? Contenu { get; set; }

        public bool Valider { get; set; }

        [MaxLength(50)]
        public string? VisibiliteLibelle { get; set; }

        [MaxLength(50)]
        public string? CategorieLibelle { get; set; }

        public int? DocumentId { get; set; }
        public Document? Document { get; set; }

        [ForeignKey("Utilisateur")]
        public int UtilisateurId { get; set; }
        [JsonIgnore]
        public Utilisateur? Utilisateur { get; set; }
        [JsonIgnore]
        public ICollection<Aimer>? Aimes { get; set; }

    }
}
