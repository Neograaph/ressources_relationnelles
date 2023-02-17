﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCube.Models.BuisnessObjects
{
    public class Relation
    {
        [Key] public int RelationId { get; set; }
        [Required]
        [NotMapped]
        public Utilisateur? Utilisateur { get; set; }
        [Required]
        [NotMapped]
        public Utilisateur? UtilisateurRelation { get; set; }
        [MaxLength(50)]
        [Required]
        public string? Libelle { get; set; }
        [Required]
        [MaxLength(150)]
        public string? Type { get; set; }
    }
}
