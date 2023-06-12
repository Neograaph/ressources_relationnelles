using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCube.Models.BuisnessObjects
{
    public class Categorie
    {
        [Key]
        public int CategorieId { get; set; }
        public string? Libelle { get; set; }

        [NotMapped]
        public ICollection<Ressource>? Ressources { get; set; }
    }
}
