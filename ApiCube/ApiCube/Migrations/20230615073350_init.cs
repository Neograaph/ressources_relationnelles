using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCube.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionTypes",
                columns: table => new
                {
                    ActionTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTypes", x => x.ActionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    AdresseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdresseNum = table.Column<int>(type: "int", nullable: false),
                    Rue = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Cp = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.AdresseId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategorieId);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Poids = table.Column<int>(type: "int", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Chemin = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "TypeRessources",
                columns: table => new
                {
                    TypeRessourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeRessources", x => x.TypeRessourceId);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    UtilisateurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    MotDePasse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    UtilisateurActif = table.Column<bool>(type: "bit", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DerniereConnexion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdresseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.UtilisateurId);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Adresses_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adresses",
                        principalColumn: "AdresseId");
                });

            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    RelationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false),
                    UtilisateurRelationId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.RelationId);
                    table.ForeignKey(
                        name: "FK_Relations_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UtilisateurId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relations_Utilisateurs_UtilisateurRelationId",
                        column: x => x.UtilisateurRelationId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UtilisateurId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ressources",
                columns: table => new
                {
                    RessourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contenu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Valider = table.Column<bool>(type: "bit", nullable: false),
                    VisibiliteLibelle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CategorieId = table.Column<int>(type: "int", nullable: false),
                    TypeRessourceId = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ressources", x => x.RessourceId);
                    table.ForeignKey(
                        name: "FK_Ressources_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "CategorieId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ressources_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                    table.ForeignKey(
                        name: "FK_Ressources_TypeRessources_TypeRessourceId",
                        column: x => x.TypeRessourceId,
                        principalTable: "TypeRessources",
                        principalColumn: "TypeRessourceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ressources_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UtilisateurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aimers",
                columns: table => new
                {
                    AimerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RessourceId = table.Column<int>(type: "int", nullable: false),
                    DateAimer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aimers", x => x.AimerId);
                    table.ForeignKey(
                        name: "FK_Aimers_Ressources_RessourceId",
                        column: x => x.RessourceId,
                        principalTable: "Ressources",
                        principalColumn: "RessourceId");
                    table.ForeignKey(
                        name: "FK_Aimers_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UtilisateurId");
                });

            migrationBuilder.CreateTable(
                name: "Commentaires",
                columns: table => new
                {
                    CommentaireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RessourceId = table.Column<int>(type: "int", nullable: false),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false),
                    CommentaireReponse = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaires", x => x.CommentaireId);
                    table.ForeignKey(
                        name: "FK_Commentaires_Ressources_RessourceId",
                        column: x => x.RessourceId,
                        principalTable: "Ressources",
                        principalColumn: "RessourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consulters",
                columns: table => new
                {
                    ConsulterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RessourceId = table.Column<int>(type: "int", nullable: false),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulters", x => x.ConsulterId);
                    table.ForeignKey(
                        name: "FK_Consulters_Ressources_RessourceId",
                        column: x => x.RessourceId,
                        principalTable: "Ressources",
                        principalColumn: "RessourceId");
                    table.ForeignKey(
                        name: "FK_Consulters_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UtilisateurId");
                });

            migrationBuilder.CreateTable(
                name: "ModererRess",
                columns: table => new
                {
                    ModererResId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RessourceId = table.Column<int>(type: "int", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: false),
                    DateModerRes = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModererRess", x => x.ModererResId);
                    table.ForeignKey(
                        name: "FK_ModererRess_ActionTypes_ActionTypeId",
                        column: x => x.ActionTypeId,
                        principalTable: "ActionTypes",
                        principalColumn: "ActionTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModererRess_Ressources_RessourceId",
                        column: x => x.RessourceId,
                        principalTable: "Ressources",
                        principalColumn: "RessourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recherchers",
                columns: table => new
                {
                    RechercherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RechercheLibelle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RechercheDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RessourceId = table.Column<int>(type: "int", nullable: false),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recherchers", x => x.RechercherId);
                    table.ForeignKey(
                        name: "FK_Recherchers_Ressources_RessourceId",
                        column: x => x.RessourceId,
                        principalTable: "Ressources",
                        principalColumn: "RessourceId");
                    table.ForeignKey(
                        name: "FK_Recherchers_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UtilisateurId");
                });

            migrationBuilder.CreateTable(
                name: "ModererComs",
                columns: table => new
                {
                    ModererComId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentaireId = table.Column<int>(type: "int", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: false),
                    DateModerCom = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModererComs", x => x.ModererComId);
                    table.ForeignKey(
                        name: "FK_ModererComs_ActionTypes_ActionTypeId",
                        column: x => x.ActionTypeId,
                        principalTable: "ActionTypes",
                        principalColumn: "ActionTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModererComs_Commentaires_CommentaireId",
                        column: x => x.CommentaireId,
                        principalTable: "Commentaires",
                        principalColumn: "CommentaireId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "AdresseId", "AdresseNum", "Cp", "Rue", "Ville" },
                values: new object[] { 1, 123, "12345", "Rue de l'Exemple", "Ville de l'Exemple" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategorieId", "Libelle" },
                values: new object[,]
                {
                    { 1, "Communication" },
                    { 2, "Cultures" },
                    { 3, "Développement personnel" },
                    { 4, "Intelligence émotionnelle" },
                    { 5, "Loisirs" },
                    { 6, "Monde professionnel" },
                    { 7, "Parentalité" },
                    { 8, "Qualité de vie" },
                    { 9, "Recherche de sens" },
                    { 10, "Santé physique" },
                    { 11, "Santé psychique" },
                    { 12, "Spiritualité" },
                    { 13, "Vie affective" }
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "DocumentId", "Chemin", "Extension", "Poids" },
                values: new object[] { 1, "image.jpeg", ".jpeg", 4000 });

            migrationBuilder.InsertData(
                table: "TypeRessources",
                columns: new[] { "TypeRessourceId", "Libelle" },
                values: new object[,]
                {
                    { 1, "Activité / Jeu à réaliser" },
                    { 2, "Article" },
                    { 3, "Carte défi" },
                    { 4, "Cours au format PDF" },
                    { 5, "Exercice / Atelier" },
                    { 6, "Fiche de lecture" },
                    { 7, "Jeu en ligne" },
                    { 8, "Vidéo" }
                });

            migrationBuilder.InsertData(
                table: "Utilisateurs",
                columns: new[] { "UtilisateurId", "AdresseId", "DateCreation", "DateNaissance", "DerniereConnexion", "Email", "MotDePasse", "Nom", "Prenom", "Role", "Telephone", "UtilisateurActif" },
                values: new object[] { 1, 1, new DateTime(2023, 6, 15, 9, 33, 50, 381, DateTimeKind.Local).AddTicks(4767), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 15, 9, 33, 50, 381, DateTimeKind.Local).AddTicks(4805), "admin@admin.com", "$2b$10$4QNhY42lquMZgUcFTPAtrO0Zuw1ytnq6pY9kL16UwtWoSqpv1gFSK", "admin", "admin", "Administrateur", "0123456789", true });

            migrationBuilder.InsertData(
                table: "Ressources",
                columns: new[] { "RessourceId", "CategorieId", "Contenu", "DateCreation", "DocumentId", "Titre", "TypeRessourceId", "UtilisateurId", "Valider", "VisibiliteLibelle" },
                values: new object[,]
                {
                    { 1, 2, "Contenu de la ressource", new DateTime(2023, 6, 15, 9, 33, 50, 381, DateTimeKind.Local).AddTicks(5031), 1, "Titre de la ressource", 1, 1, true, "Publique" },
                    { 2, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nec sapien sed odio malesuada lobortis sed ut ex. Vestibulum facilisis scelerisque elit, ac commodo magna eleifend id.", new DateTime(2023, 6, 15, 9, 33, 50, 381, DateTimeKind.Local).AddTicks(5026), null, "Ressource random", 1, 1, true, "Publique" },
                    { 3, 3, "Contenu de la ressource eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee", new DateTime(2023, 6, 15, 9, 33, 50, 381, DateTimeKind.Local).AddTicks(5034), 1, "Test", 4, 1, true, "Publique" },
                    { 4, 5, "Contenu encore", new DateTime(2023, 6, 15, 9, 33, 50, 381, DateTimeKind.Local).AddTicks(5036), 1, "Another post", 1, 1, true, "Publique" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aimers_RessourceId",
                table: "Aimers",
                column: "RessourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Aimers_UtilisateurId",
                table: "Aimers",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_RessourceId",
                table: "Commentaires",
                column: "RessourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulters_RessourceId",
                table: "Consulters",
                column: "RessourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulters_UtilisateurId",
                table: "Consulters",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_ModererComs_ActionTypeId",
                table: "ModererComs",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ModererComs_CommentaireId",
                table: "ModererComs",
                column: "CommentaireId");

            migrationBuilder.CreateIndex(
                name: "IX_ModererRess_ActionTypeId",
                table: "ModererRess",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ModererRess_RessourceId",
                table: "ModererRess",
                column: "RessourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Recherchers_RessourceId",
                table: "Recherchers",
                column: "RessourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Recherchers_UtilisateurId",
                table: "Recherchers",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_UtilisateurId",
                table: "Relations",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_UtilisateurRelationId",
                table: "Relations",
                column: "UtilisateurRelationId");

            migrationBuilder.CreateIndex(
                name: "IX_Ressources_CategorieId",
                table: "Ressources",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Ressources_DocumentId",
                table: "Ressources",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Ressources_TypeRessourceId",
                table: "Ressources",
                column: "TypeRessourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Ressources_UtilisateurId",
                table: "Ressources",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_AdresseId",
                table: "Utilisateurs",
                column: "AdresseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aimers");

            migrationBuilder.DropTable(
                name: "Consulters");

            migrationBuilder.DropTable(
                name: "ModererComs");

            migrationBuilder.DropTable(
                name: "ModererRess");

            migrationBuilder.DropTable(
                name: "Recherchers");

            migrationBuilder.DropTable(
                name: "Relations");

            migrationBuilder.DropTable(
                name: "Commentaires");

            migrationBuilder.DropTable(
                name: "ActionTypes");

            migrationBuilder.DropTable(
                name: "Ressources");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "TypeRessources");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "Adresses");
        }
    }
}
