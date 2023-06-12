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


        public int CategorieId { get; set; }
        public Categorie? Categorie { get; set; }

        public int TypeRessourceId { get; set; }
        public TypeRessource? TypeRessource { get; set; }

        public int? DocumentId { get; set; }
        public Document? Document { get; set; }

        public int UtilisateurId { get; set; }

        public Utilisateur? Utilisateur { get; set; }

        [NotMapped]
        public ICollection<Aimer>? Aimers { get; set; }

        [NotMapped]
        public ICollection<Consulter>? Consulters { get; set; }

        [NotMapped]
        public ICollection<Rechercher>? Recherchers { get; set; }

    }
}
