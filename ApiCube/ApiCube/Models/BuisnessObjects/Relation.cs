using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCube.Models.BuisnessObjects
{
    public class Relation
    {
        [Key]
        public int ID { get; set; }
        public int User1_ID { get; set; }
        public int User2_ID { get; set; }
        public int Type { get; set; }
        public string? Libelle { get; set; }
        public virtual Utilisateur User1 { get; set; }
        public virtual Utilisateur User2 { get; set; }
    }
}
    