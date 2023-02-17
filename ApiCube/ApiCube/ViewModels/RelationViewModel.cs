namespace ApiCube.Models.ViewModels
{
    public class RelationViewModel
    {
        public int ID { get; set; }
        public int User1_ID { get; set; }
        public int User2_ID { get; set; }
        public int Type { get; set; }
        public string? Libelle { get; set; }
    }
}