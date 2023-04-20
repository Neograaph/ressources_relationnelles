using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCube.Models.BuisnessObjects
{
    public class Relation
    {
        [Key] public int RelationId { get; set; }
       
        public int UtilisateurId { get; set; }
        [NotMapped]
        public Utilisateur Utilisateur { get; set; }

        public int UtilisateurRelationId { get; set; }
        [NotMapped]
        public Utilisateur UtilisateurRelation { get; set; }

        [MaxLength(50)]
        [Required]
        [Key]
        public int ID { get; set; }
        [ForeignKey("User1")]
        public int User1_ID { get; set; }

        [ForeignKey("User2")]
        public int User2_ID { get; set; }
        public int Type { get; set; }
        public string? Libelle { get; set; }
        public virtual Utilisateur? User1 { get; set; }
        public virtual Utilisateur? User2 { get; set; }
    }
}
    