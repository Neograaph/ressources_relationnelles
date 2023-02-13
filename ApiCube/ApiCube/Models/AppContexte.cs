using ApiCube.Models.BuisnessObjects;
using Microsoft.EntityFrameworkCore;

namespace ApiCube.Models
{
    public class AppContexte : DbContext
    {
        public AppContexte(DbContextOptions<AppContexte> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var connectionString = configuration.GetConnectionString("connexion");
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

    }
}
