using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiCube.Models.BuisnessObjects
{
    [Keyless]
    public class ModererCom
    {

        [Required]
        public Utilisateur? Utilisateur { get; set; }
        [Required]
        public Commentaire? Commentaire { get; set; }
        [Required]
        public ActionType? Action { get; set; }
        [Required]
        public DateTime DateModerCom{ get; set; }
}
}
