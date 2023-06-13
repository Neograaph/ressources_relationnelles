using ApiCube.Models.BuisnessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ApiCube.Models
{
    public class AppContexte : DbContext
    {
        public AppContexte(DbContextOptions<AppContexte> options) : base(options)
        {
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
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<TypeRessource> TypeRessources { get; set; }

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
            modelBuilder.Entity<Ressource>()
            .HasOne(r => r.TypeRessource)
            .WithMany(tr => tr.Ressources)
            .HasForeignKey(r => r.TypeRessourceId)
            .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Ressource>()
                .HasOne(r => r.Categorie)
                .WithMany(tr => tr.Ressources)
                .HasForeignKey(r => r.CategorieId)
                .OnDelete(DeleteBehavior.Restrict);



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

  
            modelBuilder.Entity<Categorie>().HasData(
        new Categorie { CategorieId = 1, Libelle = "Communication" },
        new Categorie { CategorieId = 2, Libelle = "Cultures" },
        new Categorie { CategorieId = 3, Libelle = "Développement personnel" },
        new Categorie { CategorieId = 4, Libelle = "Intelligence émotionnelle" },
        new Categorie { CategorieId = 5, Libelle = "Loisirs" },
        new Categorie { CategorieId = 6, Libelle = "Monde professionnel" },
        new Categorie { CategorieId = 7, Libelle = "Parentalité" },
        new Categorie { CategorieId = 8, Libelle = "Qualité de vie" },
        new Categorie { CategorieId = 9, Libelle = "Recherche de sens" },
        new Categorie { CategorieId = 10, Libelle = "Santé physique" },
        new Categorie { CategorieId = 11, Libelle = "Santé psychique" },
        new Categorie { CategorieId = 12, Libelle = "Spiritualité" },
        new Categorie { CategorieId = 13, Libelle = "Vie affective" }
    );
                modelBuilder.Entity<TypeRessource>().HasData(
           new TypeRessource { TypeRessourceId = 1, Libelle = "Activité / Jeu à réaliser" },
           new TypeRessource { TypeRessourceId = 2, Libelle = "Article" },
           new TypeRessource { TypeRessourceId = 3, Libelle = "Carte défi" },
           new TypeRessource { TypeRessourceId = 4, Libelle = "Cours au format PDF" },
           new TypeRessource { TypeRessourceId = 5, Libelle = "Exercice / Atelier" },
           new TypeRessource { TypeRessourceId = 6, Libelle = "Fiche de lecture" },
           new TypeRessource { TypeRessourceId = 7, Libelle = "Jeu en ligne" },
           new TypeRessource { TypeRessourceId = 8, Libelle = "Vidéo" }
       );
            modelBuilder.Entity<Ressource>().HasData(new Ressource
            {
                RessourceId = 2,
                Titre = "Ressource random",
                DateCreation = DateTime.Now,
                Contenu = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nec sapien sed odio malesuada lobortis sed ut ex. Vestibulum facilisis scelerisque elit, ac commodo magna eleifend id.",
                Valider = true,
                VisibiliteLibelle = "Publique",
                CategorieId = 2,
                TypeRessourceId = 1,
                UtilisateurId = 1
            },new Ressource
            {
                RessourceId = 1,
                Titre = "Titre de la ressource",
                DateCreation = DateTime.Now,
                Contenu = "Contenu de la ressource",
                Valider = true,
                VisibiliteLibelle = "Publique",
                CategorieId = 2,
                TypeRessourceId = 1,
                DocumentId = 1,
                UtilisateurId = 1
            }, new Ressource
            {
                RessourceId = 3,
                Titre = "Test",
                DateCreation = DateTime.Now,
                Contenu = "Contenu de la ressource eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee",
                Valider = true,
                VisibiliteLibelle = "Publique",
                CategorieId = 3,
                TypeRessourceId = 4,
                DocumentId = 1,
                UtilisateurId = 1
            }
            , new Ressource
            {
                RessourceId = 4,
                Titre = "Another post",
                DateCreation = DateTime.Now,
                Contenu = "Contenu encore",
                Valider = true,
                VisibiliteLibelle = "Publique",
                CategorieId = 5,
                TypeRessourceId = 1,
                DocumentId = 1,
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
