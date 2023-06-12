namespace ApiCube.Models.DTO
{
    public class PublierRessource
    {
        public int CategorieId { get; set; }
        public int TypeRessourceId { get; set; }
        public string Titre { get; set; }
        public string Contenu { get; set; }
        public IFormFile Document { get; set; }
    }
}
