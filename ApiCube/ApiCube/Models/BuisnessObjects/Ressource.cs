using System.ComponentModel.DataAnnotations;

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

        public int DocumentId { get; set; }
        public Document? Document { get; set; }

        public int UtilisateurId { get; set; }

        public Utilisateur Utilisateur { get; set; }

    }
}
