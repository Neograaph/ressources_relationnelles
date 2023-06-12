using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiCube.Models.BuisnessObjects
{
    public class TypeRessource
    {
        [Key]
        public int TypeRessourceId { get; set; }
        public string? Libelle { get; set; }
        [NotMapped]
        [JsonIgnore]
        public ICollection<Ressource>? Ressources { get; set; }
    }
}
