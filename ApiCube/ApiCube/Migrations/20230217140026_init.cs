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
                name: "Utilisateurs",
                columns: table => new
                {
                    UtilisateurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    MotDePasse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    UtilisateurActif = table.Column<bool>(type: "bit", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DerniereConnexion = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    CategorieLibelle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ressources", x => x.RessourceId);
                    table.ForeignKey(
                        name: "FK_Ressources_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User1_ID = table.Column<int>(type: "int", nullable: false),
                    User2_ID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Relations_Utilisateurs_User1_ID",
                        column: x => x.User1_ID,
                        principalTable: "Utilisateurs",
                        principalColumn: "UtilisateurId",
                         onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Relations_Utilisateurs_User2_ID",
                        column: x => x.User2_ID,
                        principalTable: "Utilisateurs",
                        principalColumn: "UtilisateurId",
                         onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Aimers",
                columns: table => new
                {
                    AimerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RessourceId = table.Column<int>(type: "int", nullable: false),
                    DateAimer = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aimers", x => x.AimerId);
                    table.ForeignKey(
                        name: "FK_Aimers_Ressources_RessourceId",
                        column: x => x.RessourceId,
                        principalTable: "Ressources",
                        principalColumn: "RessourceId",
                        onDelete: ReferentialAction.Cascade);
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
                    CommentaireReponse = table.Column<int>(type: "int", nullable: false)
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
                    RessourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulters", x => x.ConsulterId);
                    table.ForeignKey(
                        name: "FK_Consulters_Ressources_RessourceId",
                        column: x => x.RessourceId,
                        principalTable: "Ressources",
                        principalColumn: "RessourceId",
                        onDelete: ReferentialAction.Cascade);
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
                    RessourceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recherchers", x => x.RechercherId);
                    table.ForeignKey(
                        name: "FK_Recherchers_Ressources_RessourceId",
                        column: x => x.RessourceId,
                        principalTable: "Ressources",
                        principalColumn: "RessourceId");
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

            migrationBuilder.CreateIndex(
                name: "IX_Aimers_RessourceId",
                table: "Aimers",
                column: "RessourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_RessourceId",
                table: "Commentaires",
                column: "RessourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulters_RessourceId",
                table: "Consulters",
                column: "RessourceId");

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
                name: "IX_Relations_User1_ID",
                table: "Relations",
                column: "User1_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_User2_ID",
                table: "Relations",
                column: "User2_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Ressources_DocumentId",
                table: "Ressources",
                column: "DocumentId");

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
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "Ressources");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "Documents");
        }
    }
}
