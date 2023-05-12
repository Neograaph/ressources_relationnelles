using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCube.Models.BuisnessObjects
{
    public class Utilisateur
    {
        [Key]
        public int UtilisateurId { get; set; }
        [MaxLength(150)]
        public string? Nom { get; set; }
        [MaxLength(150)]
        public string? Prenom { get; set; }
        public string? MotDePasse { get; set; }
        [MaxLength(15)]
        public string? Telephone { get; set; }
        [MaxLength(150)]
        public string? Email { get;set; }
        public bool UtilisateurActif { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DerniereConnexion { get; set; }
        [Required]
        [MaxLength(50)]
        public string Role { get; set; }

        public int? AdresseId { get; set; }

        public Adresse? Adresse { get; set; }

        [NotMapped]
        public ICollection<Aimer>? Aimers { get; set; }
        [NotMapped]
        public ICollection<Consulter>? Consulters { get; set; }
        [NotMapped]
        public ICollection<Rechercher>? Recherchers { get; set; }
        //[NotMapped]

        //[JsonIgnore]
        //public virtual ICollection<ModererCom>? ModererComs { get; set; }
        //[NotMapped]
        //[JsonIgnore]
        //public virtual ICollection<ModererRes>? ModererRess { get; set; }
        //[NotMapped]
        //[JsonIgnore]

        //private ICollection<ModererCom>? _modererComs;
        //[NotMapped]
        //public virtual ICollection<ModererCom> ModererComs
        //{
        //    get
        //    {
        //        if (Role == "3")
        //        {
        //            return _modererComs ??= new List<ModererCom>();
        //        }
        //        else
        //        {
        //            throw new UnauthorizedAccessException("L'utilisateur n'a pas le rôle requis pour accéder à cette propriété.");
        //        }
        //    }
        //}
        //[NotMapped]
        //private ICollection<ModererRes>? _modererRess;
        //[NotMapped]
        //public virtual ICollection<ModererRes> ModererRess
        //{
        //    get
        //    {
        //        if (Role == "3")
        //        {
        //            return _modererRess ??= new List<ModererRes>();
        //        }
        //        else
        //        {
        //            throw new UnauthorizedAccessException("L'utilisateur n'a pas le rôle requis pour accéder à cette propriété.");
        //        }
        //    }
        //}

        [NotMapped]

        public virtual ICollection<Relation>? Relations { get; set; }
    }
}
