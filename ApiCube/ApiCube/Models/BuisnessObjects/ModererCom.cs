using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiCube.Models.BuisnessObjects
{
    public class ModererCom
    {

        [Key]
        public int ModererComId { get; set; }
       
        [Required]
        public Commentaire? Commentaire { get; set; }
        [Required]
        public ActionType? Action { get; set; }
        [Required]
        public DateTime DateModerCom{ get; set; }
}
}
