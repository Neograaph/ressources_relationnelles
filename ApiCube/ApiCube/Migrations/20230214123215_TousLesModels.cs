using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCube.Migrations
{
    public partial class TousLesModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "Utilisateurs",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Utilisateurs",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdresseId",
                table: "Utilisateurs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "Utilisateurs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DerniereConnexion",
                table: "Utilisateurs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Utilisateurs",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotDePasse",
                table: "Utilisateurs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Utilisateurs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "Utilisateurs",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UtilisateurActif",
                table: "Utilisateurs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Adresse",
                columns: table => new
                {
                    AdresseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rue = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Cp = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresse", x => x.AdresseId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_AdresseId",
                table: "Utilisateurs",
                column: "AdresseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_Adresse_AdresseId",
                table: "Utilisateurs",
                column: "AdresseId",
                principalTable: "Adresse",
                principalColumn: "AdresseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_Adresse_AdresseId",
                table: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "Adresse");

            migrationBuilder.DropIndex(
                name: "IX_Utilisateurs_AdresseId",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "AdresseId",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "DateCreation",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "DerniereConnexion",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "MotDePasse",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "UtilisateurActif",
                table: "Utilisateurs");

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "Utilisateurs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Utilisateurs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);
        }
    }
}
