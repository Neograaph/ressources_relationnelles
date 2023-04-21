using System.ComponentModel.DataAnnotations;

namespace ApiCube.Models.BuisnessObjects
{
    public class Commentaire
    {
        [Key]
        public int CommentaireId { get; set; }

        [MaxLength(255)]
        [Required]
        public string? Message { get; set; }

        [Required]
        public DateTime? DateCreation { get; set; }
        [Required]
        public Ressource? Ressource { get; set; }

        public int UtilisateurId { get; set; }

        public int? CommentaireReponse { get; set; }
    }
}
