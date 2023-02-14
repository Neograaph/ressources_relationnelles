using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiCube.Models.BuisnessObjects
{
    [Keyless]
    public class ModererRes
    {
        [Required]
        public Utilisateur? Utilisateur { get; set; }
        [Required]
        public Ressource? Ressource { get; set; }
        [Required]
        public ActionType? Action { get; set; }
        [Required]
        public DateTime DateModerRes { get; set; }
    }
}
