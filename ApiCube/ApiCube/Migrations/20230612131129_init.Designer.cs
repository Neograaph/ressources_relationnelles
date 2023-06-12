﻿// <auto-generated />
using System;
using ApiCube.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiCube.Migrations
{
    [DbContext(typeof(AppContexte))]
    [Migration("20230612131129_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.ActionType", b =>
                {
                    b.Property<int>("ActionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActionTypeId"), 1L, 1);

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ActionTypeId");

                    b.ToTable("ActionTypes");
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.Adresse", b =>
                {
                    b.Property<int>("AdresseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdresseId"), 1L, 1);

                    b.Property<int>("AdresseNum")
                        .HasColumnType("int");

                    b.Property<string>("Cp")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Rue")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("AdresseId");

                    b.ToTable("Adresses");

                    b.HasData(
                        new
                        {
                            AdresseId = 1,
                            AdresseNum = 123,
                            Cp = "12345",
                            Rue = "Rue de l'Exemple",
                            Ville = "Ville de l'Exemple"
                        });
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.Aimer", b =>
                {
                    b.Property<int>("AimerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AimerId"), 1L, 1);

                    b.Property<DateTime>("DateAimer")
                        .HasColumnType("datetime2");

                    b.Property<int>("RessourceId")
                        .HasColumnType("int");

                    b.Property<int>("UtilisateurId")
                        .HasColumnType("int");

                    b.HasKey("AimerId");

                    b.HasIndex("RessourceId");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("Aimers");
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.Categorie", b =>
                {
                    b.Property<int>("CategorieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategorieId"), 1L, 1);

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategorieId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategorieId = 1,
                            Libelle = "Communication"
                        },
                        new
                        {
                            CategorieId = 2,
                            Libelle = "Cultures"
                        },
                        new
                        {
                            CategorieId = 3,
                            Libelle = "Développement personnel"
                        },
                        new
                        {
                            CategorieId = 4,
                            Libelle = "Intelligence émotionnelle"
                        },
                        new
                        {
                            CategorieId = 5,
                            Libelle = "Loisirs"
                        },
                        new
                        {
                            CategorieId = 6,
                            Libelle = "Monde professionnel"
                        },
                        new
                        {
                            CategorieId = 7,
                            Libelle = "Parentalité"
                        },
                        new
                        {
                            CategorieId = 8,
                            Libelle = "Qualité de vie"
                        },
                        new
                        {
                            CategorieId = 9,
                            Libelle = "Recherche de sens"
                        },
                        new
                        {
                            CategorieId = 10,
                            Libelle = "Santé physique"
                        },
                        new
                        {
                            CategorieId = 11,
                            Libelle = "Santé psychique"
                        },
                        new
                        {
                            CategorieId = 12,
                            Libelle = "Spiritualité"
                        },
                        new
                        {
                            CategorieId = 13,
                            Libelle = "Vie affective"
                        });
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.Commentaire", b =>
                {
                    b.Property<int>("CommentaireId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentaireId"), 1L, 1);

                    b.Property<int?>("CommentaireReponse")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreation")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("RessourceId")
                        .HasColumnType("int");

                    b.Property<int>("UtilisateurId")
                        .HasColumnType("int");

                    b.HasKey("CommentaireId");

                    b.HasIndex("RessourceId");

                    b.ToTable("Commentaires");
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.Consulter", b =>
                {
                    b.Property<int>("ConsulterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConsulterId"), 1L, 1);

                    b.Property<int>("RessourceId")
                        .HasColumnType("int");

                    b.Property<int>("UtilisateurId")
                        .HasColumnType("int");

                    b.HasKey("ConsulterId");

                    b.HasIndex("RessourceId");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("Consulters");
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentId"), 1L, 1);

                    b.Property<string>("Chemin")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Poids")
                        .HasColumnType("int");

                    b.HasKey("DocumentId");

                    b.ToTable("Documents");

                    b.HasData(
                        new
                        {
                            DocumentId = 1,
                            Chemin = "/chemin/vers/document.pdf",
                            Extension = ".pdf",
                            Poids = 100
                        });
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.ModererCom", b =>
                {
                    b.Property<int>("ModererComId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModererComId"), 1L, 1);

                    b.Property<int>("ActionTypeId")
                        .HasColumnType("int");

                    b.Property<int>("CommentaireId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateModerCom")
                        .HasColumnType("datetime2");

                    b.HasKey("ModererComId");

                    b.HasIndex("ActionTypeId");

                    b.HasIndex("CommentaireId");

                    b.ToTable("ModererComs");
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.ModererRes", b =>
                {
                    b.Property<int>("ModererResId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModererResId"), 1L, 1);

                    b.Property<int>("ActionTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateModerRes")
                        .HasColumnType("datetime2");

                    b.Property<int>("RessourceId")
                        .HasColumnType("int");

                    b.HasKey("ModererResId");

                    b.HasIndex("ActionTypeId");

                    b.HasIndex("RessourceId");

                    b.ToTable("ModererRess");
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.Rechercher", b =>
                {
                    b.Property<int>("RechercherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RechercherId"), 1L, 1);

                    b.Property<DateTime?>("RechercheDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RechercheLibelle")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("RessourceId")
                        .HasColumnType("int");

                    b.Property<int>("UtilisateurId")
                        .HasColumnType("int");

                    b.HasKey("RechercherId");

                    b.HasIndex("RessourceId");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("Recherchers");
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.Relation", b =>
                {
                    b.Property<int>("RelationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RelationId"), 1L, 1);

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("UtilisateurId")
                        .HasColumnType("int");

                    b.Property<int>("UtilisateurRelationId")
                        .HasColumnType("int");

                    b.HasKey("RelationId");

                    b.HasIndex("UtilisateurId");

                    b.HasIndex("UtilisateurRelationId");

                    b.ToTable("Relations");
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.Ressource", b =>
                {
                    b.Property<int>("RessourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RessourceId"), 1L, 1);

                    b.Property<int>("CategorieId")
                        .HasColumnType("int");

                    b.Property<string>("Contenu")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DocumentId")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("TypeRessourceId")
                        .HasColumnType("int");

                    b.Property<int>("UtilisateurId")
                        .HasColumnType("int");

                    b.Property<bool>("Valider")
                        .HasColumnType("bit");

                    b.Property<string>("VisibiliteLibelle")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RessourceId");

                    b.HasIndex("CategorieId");

                    b.HasIndex("DocumentId");

                    b.HasIndex("TypeRessourceId");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("Ressources");

                    b.HasData(
                        new
                        {
                            RessourceId = 2,
                            CategorieId = 2,
                            Contenu = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nec sapien sed odio malesuada lobortis sed ut ex. Vestibulum facilisis scelerisque elit, ac commodo magna eleifend id.",
                            DateCreation = new DateTime(2023, 6, 12, 15, 11, 28, 684, DateTimeKind.Local).AddTicks(1809),
                            Titre = "Ressource random",
                            TypeRessourceId = 1,
                            UtilisateurId = 1,
                            Valider = true,
                            VisibiliteLibelle = "Publique"
                        },
                        new
                        {
                            RessourceId = 1,
                            CategorieId = 2,
                            Contenu = "Contenu de la ressource",
                            DateCreation = new DateTime(2023, 6, 12, 15, 11, 28, 684, DateTimeKind.Local).AddTicks(1878),
                            DocumentId = 1,
                            Titre = "Titre de la ressource",
                            TypeRessourceId = 1,
                            UtilisateurId = 1,
                            Valider = true,
                            VisibiliteLibelle = "Publique"
                        });
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.TypeRessource", b =>
                {
                    b.Property<int>("TypeRessourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeRessourceId"), 1L, 1);

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeRessourceId");

                    b.ToTable("TypeRessources");

                    b.HasData(
                        new
                        {
                            TypeRessourceId = 1,
                            Libelle = "Activité / Jeu à réaliser"
                        },
                        new
                        {
                            TypeRessourceId = 2,
                            Libelle = "Article"
                        },
                        new
                        {
                            TypeRessourceId = 3,
                            Libelle = "Carte défi"
                        },
                        new
                        {
                            TypeRessourceId = 4,
                            Libelle = "Cours au format PDF"
                        },
                        new
                        {
                            TypeRessourceId = 5,
                            Libelle = "Exercice / Atelier"
                        },
                        new
                        {
                            TypeRessourceId = 6,
                            Libelle = "Fiche de lecture"
                        },
                        new
                        {
                            TypeRessourceId = 7,
                            Libelle = "Jeu en ligne"
                        },
                        new
                        {
                            TypeRessourceId = 8,
                            Libelle = "Vidéo"
                        });
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.Utilisateur", b =>
                {
                    b.Property<int>("UtilisateurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UtilisateurId"), 1L, 1);

                    b.Property<int?>("AdresseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DerniereConnexion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("MotDePasse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Prenom")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telephone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("UtilisateurActif")
                        .HasColumnType("bit");

                    b.HasKey("UtilisateurId");

                    b.HasIndex("AdresseId");

                    b.ToTable("Utilisateurs");

                    b.HasData(
                        new
                        {
                            UtilisateurId = 1,
                            AdresseId = 1,
                            DateCreation = new DateTime(2023, 6, 12, 15, 11, 28, 684, DateTimeKind.Local).AddTicks(1595),
                            DateNaissance = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DerniereConnexion = new DateTime(2023, 6, 12, 15, 11, 28, 684, DateTimeKind.Local).AddTicks(1632),
                            Email = "john.doe@example.com",
                            MotDePasse = "123456",
                            Nom = "John",
                            Prenom = "Doe",
                            Role = "Utilisateur",
                            Telephone = "0123456789",
                            UtilisateurActif = true
                        });
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.Aimer", b =>
                {
                    b.HasOne("ApiCube.Models.BuisnessObjects.Ressource", "Ressource")
                        .WithMany("Aimers")
                        .HasForeignKey("RessourceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ApiCube.Models.BuisnessObjects.Utilisateur", "Utilisateur")
                        .WithMany("Aimers")
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Ressource");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.Commentaire", b =>
                {
                    b.HasOne("ApiCube.Models.BuisnessObjects.Ressource", "Ressource")
                        .WithMany()
                        .HasForeignKey("RessourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ressource");
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.Consulter", b =>
                {
                    b.HasOne("ApiCube.Models.BuisnessObjects.Ressource", "Ressource")
                        .WithMany("Consulters")
                        .HasForeignKey("RessourceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ApiCube.Models.BuisnessObjects.Utilisateur", "Utilisateur")
                        .WithMany("Consulters")
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Ressource");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.ModererCom", b =>
                {
                    b.HasOne("ApiCube.Models.BuisnessObjects.ActionType", "Action")
                        .WithMany()
                        .HasForeignKey("ActionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiCube.Models.BuisnessObjects.Commentaire", "Commentaire")
                        .WithMany()
                        .HasForeignKey("CommentaireId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Action");

                    b.Navigation("Commentaire");
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.ModererRes", b =>
                {
                    b.HasOne("ApiCube.Models.BuisnessObjects.ActionType", "Action")
                        .WithMany()
                        .HasForeignKey("ActionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiCube.Models.BuisnessObjects.Ressource", "Ressource")
                        .WithMany()
                        .HasForeignKey("RessourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Action");

                    b.Navigation("Ressource");
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.Rechercher", b =>
                {
                    b.HasOne("ApiCube.Models.BuisnessObjects.Ressource", "Ressource")
                        .WithMany("Recherchers")
                        .HasForeignKey("RessourceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ApiCube.Models.BuisnessObjects.Utilisateur", "Utilisateur")
                        .WithMany("Recherchers")
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Ressource");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.Relation", b =>
                {
                    b.HasOne("ApiCube.Models.BuisnessObjects.Utilisateur", "Utilisateur")
                        .WithMany()
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApiCube.Models.BuisnessObjects.Utilisateur", "UtilisateurRelation")
                        .WithMany()
                        .HasForeignKey("UtilisateurRelationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Utilisateur");

                    b.Navigation("UtilisateurRelation");
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.Ressource", b =>
                {
                    b.HasOne("ApiCube.Models.BuisnessObjects.Categorie", "Categorie")
                        .WithMany("Ressources")
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApiCube.Models.BuisnessObjects.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId");

                    b.HasOne("ApiCube.Models.BuisnessObjects.TypeRessource", "TypeRessource")
                        .WithMany("Ressources")
                        .HasForeignKey("TypeRessourceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApiCube.Models.BuisnessObjects.Utilisateur", "Utilisateur")
                        .WithMany()
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("Document");

                    b.Navigation("TypeRessource");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.Utilisateur", b =>
                {
                    b.HasOne("ApiCube.Models.BuisnessObjects.Adresse", "Adresse")
                        .WithMany()
                        .HasForeignKey("AdresseId");

                    b.Navigation("Adresse");
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.Categorie", b =>
                {
                    b.Navigation("Ressources");
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.Ressource", b =>
                {
                    b.Navigation("Aimers");

                    b.Navigation("Consulters");

                    b.Navigation("Recherchers");
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.TypeRessource", b =>
                {
                    b.Navigation("Ressources");
                });

            modelBuilder.Entity("ApiCube.Models.BuisnessObjects.Utilisateur", b =>
                {
                    b.Navigation("Aimers");

                    b.Navigation("Consulters");

                    b.Navigation("Recherchers");
                });
#pragma warning restore 612, 618
        }
    }
}
