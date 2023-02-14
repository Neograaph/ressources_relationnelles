using System.ComponentModel.DataAnnotations;

namespace ApiCube.Models.BuisnessObjects
{
    public class ActionType
    {
        [Key]
        public int ActionTypeId { get; set; }

        [MaxLength(50)]
        [Required]
        public string? Libelle { get; set; }

    }
}
