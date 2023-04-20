namespace ApiCube.Models.DTO
{
    // classe pour l'authentification des uilisateurs
    public class AuthentificationRequest
    {
        public string Email { get; set; }
        public string MotDePasse { get; set; }
    }
}
