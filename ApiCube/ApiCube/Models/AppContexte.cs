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


            modelBuilder.Entity<Utilisateur>().HasData(new Utilisateur
            {
                UtilisateurId = 1,
                Nom = "John",
                Prenom = "Doe",
                MotDePasse = "123456",
                Telephone = "0123456789",
                Email = "john.doe@example.com",
                UtilisateurActif = true,
                DateCreation = DateTime.Now,
                DerniereConnexion = DateTime.Now,
                Role = "Utilisateur",
                AdresseId = 1 // Clé étrangère vers l'adresse
            });

            modelBuilder.Entity<Adresse>().HasData(new Adresse
            {
                AdresseId = 1,
                AdresseNum = 123,
                Rue = "Rue de l'Exemple",
                Cp = "12345",
                Ville = "Ville de l'Exemple"
            });

            modelBuilder.Entity<Ressource>().HasData(new Ressource
            {
                RessourceId = 1,
                Titre = "Titre de la ressource",
                DateCreation = DateTime.Now,
                Contenu = "Contenu de la ressource",
                Valider = true,
                VisibiliteLibelle = "Publique",
                CategorieLibelle = "Catégorie",
                DocumentId = 1,
                UtilisateurId = 1
            });
            modelBuilder.Entity<Ressource>().HasData(new Ressource
            {
                RessourceId = 2,
                Titre = "Ressource random",
                DateCreation = DateTime.Now,
                Contenu = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nec sapien sed odio malesuada lobortis sed ut ex. Vestibulum facilisis scelerisque elit, ac commodo magna eleifend id.",
                Valider = true,
                VisibiliteLibelle = "Publique",
                CategorieLibelle = "Culture",
                UtilisateurId = 1
            });

            modelBuilder.Entity<Document>().HasData(new Document
            {
                DocumentId = 1,
                Poids = 100,
                Extension = ".pdf",
                Chemin = "/chemin/vers/document.pdf"
            });



            base.OnModelCreating(modelBuilder);

        }

    }
}
