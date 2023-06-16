namespace ApiCube.Models.DTO
{
    public class PublierRessource
    {
        public int CategorieId { get; set; }
        public int TypeRessourceId { get; set; }
        public string Titre { get; set; }
        public string Contenu { get; set; }
        public IFormFile Fichier { get; set; }
        public int UtilisateurId { get; set; } // UtilisateurId avec un "I" en majuscule
    }

}
