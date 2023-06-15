using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCube.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ressources",
                keyColumn: "RessourceId",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2023, 6, 14, 18, 19, 41, 963, DateTimeKind.Local).AddTicks(7172));

            migrationBuilder.UpdateData(
                table: "Ressources",
                keyColumn: "RessourceId",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2023, 6, 14, 18, 19, 41, 963, DateTimeKind.Local).AddTicks(7167));

            migrationBuilder.UpdateData(
                table: "Ressources",
                keyColumn: "RessourceId",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2023, 6, 14, 18, 19, 41, 963, DateTimeKind.Local).AddTicks(7175));

            migrationBuilder.UpdateData(
                table: "Ressources",
                keyColumn: "RessourceId",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2023, 6, 14, 18, 19, 41, 963, DateTimeKind.Local).AddTicks(7178));

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: 1,
                columns: new[] { "DateCreation", "DerniereConnexion" },
                values: new object[] { new DateTime(2023, 6, 14, 18, 19, 41, 963, DateTimeKind.Local).AddTicks(6891), new DateTime(2023, 6, 14, 18, 19, 41, 963, DateTimeKind.Local).AddTicks(6934) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ressources",
                keyColumn: "RessourceId",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2023, 6, 14, 17, 40, 36, 327, DateTimeKind.Local).AddTicks(7065));

            migrationBuilder.UpdateData(
                table: "Ressources",
                keyColumn: "RessourceId",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2023, 6, 14, 17, 40, 36, 327, DateTimeKind.Local).AddTicks(7060));

            migrationBuilder.UpdateData(
                table: "Ressources",
                keyColumn: "RessourceId",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2023, 6, 14, 17, 40, 36, 327, DateTimeKind.Local).AddTicks(7068));

            migrationBuilder.UpdateData(
                table: "Ressources",
                keyColumn: "RessourceId",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2023, 6, 14, 17, 40, 36, 327, DateTimeKind.Local).AddTicks(7071));

            migrationBuilder.UpdateData(
                table: "Utilisateurs",
                keyColumn: "UtilisateurId",
                keyValue: 1,
                columns: new[] { "DateCreation", "DerniereConnexion" },
                values: new object[] { new DateTime(2023, 6, 14, 17, 40, 36, 327, DateTimeKind.Local).AddTicks(6826), new DateTime(2023, 6, 14, 17, 40, 36, 327, DateTimeKind.Local).AddTicks(6861) });
        }
    }
}
