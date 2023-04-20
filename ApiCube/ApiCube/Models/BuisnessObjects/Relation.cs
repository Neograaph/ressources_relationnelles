using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCube.Models.BuisnessObjects
{
    public class Relation
    {
        [Key] 
        public int RelationId { get; set; }
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public int UtilisateurRelationId { get; set; }
        public Utilisateur UtilisateurRelation { get; set; }
        public int Type { get; set; }
        public string? Libelle { get; set; }

    }
}
    