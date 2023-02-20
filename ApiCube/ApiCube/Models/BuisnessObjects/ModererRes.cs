using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace ApiCube.Models.BuisnessObjects
{
    public class ModererRes
    {
        [Key]
        public int ModererResId { get; set; }
        
        [Required]
        public Ressource? Ressource { get; set; }
        [Required]
        public ActionType? Action { get; set; }
        [Required]
        public DateTime DateModerRes { get; set; }

        public int UtilisateurId { get; set; }
    }
}
