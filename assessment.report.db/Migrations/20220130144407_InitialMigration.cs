using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace assessment.report.db.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RaporDurum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Durum = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaporDurum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rapor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TalepTarihi = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RaporDurumId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rapor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rapor_RaporDurum_RaporDurumId",
                        column: x => x.RaporDurumId,
                        principalTable: "RaporDurum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rapor_RaporDurumId",
                table: "Rapor",
                column: "RaporDurumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rapor");

            migrationBuilder.DropTable(
                name: "RaporDurum");
        }
    }
}
