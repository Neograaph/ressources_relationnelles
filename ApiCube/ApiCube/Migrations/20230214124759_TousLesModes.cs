using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCube.Migrations
{
    public partial class TousLesModes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_Adresse_AdresseId",
                table: "Utilisateurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adresse",
                table: "Adresse");

            migrationBuilder.RenameTable(
                name: "Adresse",
                newName: "Adresses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adresses",
                table: "Adresses",
                column: "AdresseId");

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
                name: "Relations",
                columns: table => new
                {
                    UtilisateurId = table.Column<int>(type: "int", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Relations_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UtilisateurId",
                        onDelete: ReferentialAction.Cascade);
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
                    DocumentId = table.Column<int>(type: "int", nullable: false)
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
                name: "Aimers",
                columns: table => new
                {
                    UtilisateurId = table.Column<int>(type: "int", nullable: false),
                    RessourceId = table.Column<int>(type: "int", nullable: false),
                    DateAimer = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Aimers_Ressources_RessourceId",
                        column: x => x.RessourceId,
                        principalTable: "Ressources",
                        principalColumn: "RessourceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aimers_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UtilisateurId",
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
                    RessourceId1 = table.Column<int>(type: "int", nullable: false),
                    UtilisateurId1 = table.Column<int>(type: "int", nullable: false),
                    CommentaireReponse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaires", x => x.CommentaireId);
                    table.ForeignKey(
                        name: "FK_Commentaires_Ressources_RessourceId1",
                        column: x => x.RessourceId1,
                        principalTable: "Ressources",
                        principalColumn: "RessourceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commentaires_Utilisateurs_UtilisateurId1",
                        column: x => x.UtilisateurId1,
                        principalTable: "Utilisateurs",
                        principalColumn: "UtilisateurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consulters",
                columns: table => new
                {
                    UtilisateurId = table.Column<int>(type: "int", nullable: false),
                    RessourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Consulters_Ressources_RessourceId",
                        column: x => x.RessourceId,
                        principalTable: "Ressources",
                        principalColumn: "RessourceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulters_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UtilisateurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModererRess",
                columns: table => new
                {
                    UtilisateurId = table.Column<int>(type: "int", nullable: false),
                    RessourceId = table.Column<int>(type: "int", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: false),
                    DateModerRes = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
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
                    table.ForeignKey(
                        name: "FK_ModererRess_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UtilisateurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recherchers",
                columns: table => new
                {
                    RechercheLibelle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RechercheDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RessourceId = table.Column<int>(type: "int", nullable: true),
                    UtilisateurId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
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
                    UtilisateurId = table.Column<int>(type: "int", nullable: false),
                    CommentaireId = table.Column<int>(type: "int", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: false),
                    DateModerCom = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
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
                    table.ForeignKey(
                        name: "FK_ModererComs_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "UtilisateurId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Commentaires_RessourceId1",
                table: "Commentaires",
                column: "RessourceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_UtilisateurId1",
                table: "Commentaires",
                column: "UtilisateurId1");

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
                name: "IX_ModererComs_UtilisateurId",
                table: "ModererComs",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_ModererRess_ActionTypeId",
                table: "ModererRess",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ModererRess_RessourceId",
                table: "ModererRess",
                column: "RessourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ModererRess_UtilisateurId",
                table: "ModererRess",
                column: "UtilisateurId");

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
                name: "IX_Ressources_DocumentId",
                table: "Ressources",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_Adresses_AdresseId",
                table: "Utilisateurs",
                column: "AdresseId",
                principalTable: "Adresses",
                principalColumn: "AdresseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_Adresses_AdresseId",
                table: "Utilisateurs");

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
                name: "Documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adresses",
                table: "Adresses");

            migrationBuilder.RenameTable(
                name: "Adresses",
                newName: "Adresse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adresse",
                table: "Adresse",
                column: "AdresseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_Adresse_AdresseId",
                table: "Utilisateurs",
                column: "AdresseId",
                principalTable: "Adresse",
                principalColumn: "AdresseId");
        }
    }
}
