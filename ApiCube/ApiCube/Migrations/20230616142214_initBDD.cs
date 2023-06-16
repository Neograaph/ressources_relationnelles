using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCube.Migrations
{
    public partial class initBDD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ressources",
                keyColumn: "RessourceId",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2023, 6, 16, 16, 22, 13, 731, DateTimeKind.Local).AddTicks(5488));

            migrationBuilder.UpdateData(
                table: "Ressources",
                keyColumn: "RessourceId",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2023, 6, 16, 16, 22, 13, 731, DateTimeKind.Local).AddTicks(5483));

            migrationBuilder.UpdateData(
                table: "Ressources",
                keyColumn: "RessourceId",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2023, 6, 16, 16, 22, 13, 731, DateTimeKind.Local).AddTicks(5491));

            migrationBuilder.UpdateData(
                table: "Ressources",
                keyColumn: "RessourceId",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2023, 6, 16, 16, 22, 13, 731, DateTimeKind.Local).AddTicks(5494));

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: 1,
                columns: new[] { "DateCreation", "DerniereConnexion" },
                values: new object[] { new DateTime(2023, 6, 16, 16, 22, 13, 731, DateTimeKind.Local).AddTicks(5257), new DateTime(2023, 6, 16, 16, 22, 13, 731, DateTimeKind.Local).AddTicks(5293) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ressources",
                keyColumn: "RessourceId",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2023, 6, 15, 9, 33, 50, 381, DateTimeKind.Local).AddTicks(5031));

            migrationBuilder.UpdateData(
                table: "Ressources",
                keyColumn: "RessourceId",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2023, 6, 15, 9, 33, 50, 381, DateTimeKind.Local).AddTicks(5026));

            migrationBuilder.UpdateData(
                table: "Ressources",
                keyColumn: "RessourceId",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2023, 6, 15, 9, 33, 50, 381, DateTimeKind.Local).AddTicks(5034));

            migrationBuilder.UpdateData(
                table: "Ressources",
                keyColumn: "RessourceId",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2023, 6, 15, 9, 33, 50, 381, DateTimeKind.Local).AddTicks(5036));

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: 1,
                columns: new[] { "DateCreation", "DerniereConnexion" },
                values: new object[] { new DateTime(2023, 6, 15, 9, 33, 50, 381, DateTimeKind.Local).AddTicks(4767), new DateTime(2023, 6, 15, 9, 33, 50, 381, DateTimeKind.Local).AddTicks(4805) });
        }
    }
}
