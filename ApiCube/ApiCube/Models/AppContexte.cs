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
        public DbSet<ActionType> ActionTypes { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Aimer> Aimers { get; set; }
        public DbSet<Consulter> Consulters { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<ModererCom> ModererComs { get; set; }
        public DbSet<ModererRes> ModererRess { get; set; }
        public DbSet<Rechercher> Recherchers { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<Ressource> Ressources { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Relation>()
        //        .HasOne(r => r.User1)
        //        .WithMany()
        //        .HasForeignKey(r => r.User1_ID);

        //    modelBuilder.Entity<Relation>()
        //        .HasOne(r => r.User2)
        //        .WithMany()
        //        .HasForeignKey(r => r.User2_ID)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Relation>()
                .HasOne(r => r.Utilisateur)
                .WithMany()
                .HasForeignKey(r => r.UtilisateurId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Relation>()
                .HasOne(r => r.UtilisateurRelation)
                .WithMany()
                .HasForeignKey(r => r.UtilisateurRelationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Aimer>()
            .HasOne(a => a.Utilisateur)
            .WithMany(u => u.Aimers)
            .HasForeignKey(a => a.UtilisateurId)
            .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Aimer>()
                .HasOne(a => a.Ressource)
                .WithMany(r => r.Aimers)
                .HasForeignKey(a => a.RessourceId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Consulter>()
            .HasOne(a => a.Utilisateur)
            .WithMany(u => u.Consulters)
            .HasForeignKey(a => a.UtilisateurId)
            .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Consulter>()
                .HasOne(a => a.Ressource)
                .WithMany(r => r.Consulters)
                .HasForeignKey(a => a.RessourceId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Rechercher>()
            .HasOne(a => a.Utilisateur)
            .WithMany(u => u.Recherchers)
            .HasForeignKey(a => a.UtilisateurId)
            .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Rechercher>()
                .HasOne(a => a.Ressource)
                .WithMany(r => r.Recherchers)
                .HasForeignKey(a => a.RessourceId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
