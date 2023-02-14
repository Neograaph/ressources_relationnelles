using System.ComponentModel.DataAnnotations;

namespace ApiCube.Models.BuisnessObjects
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }
        [Required]
        public int Poids { get; set; }
        [MaxLength(10)]
        [Required]
        public string? Extension { get; set; }
        [MaxLength(150)]
        [Required]
        public string? Chemin { get; set; }

    }
}
