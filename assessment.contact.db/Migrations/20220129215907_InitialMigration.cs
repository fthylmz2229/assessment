using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace assessment.contact.db.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IletisimBilgiTipi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IletisimBilgiTipi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kisi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: true),
                    Soyad = table.Column<string>(type: "text", nullable: true),
                    Firma = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KisiIletisimBilgi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IletisimBilgiTipiId = table.Column<int>(type: "integer", nullable: false),
                    BilgiIcerigi = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KisiIletisimBilgi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KisiIletisimBilgi_IletisimBilgiTipi_IletisimBilgiTipiId",
                        column: x => x.IletisimBilgiTipiId,
                        principalTable: "IletisimBilgiTipi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KisiIletisimBilgi_IletisimBilgiTipiId",
                table: "KisiIletisimBilgi",
                column: "IletisimBilgiTipiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kisi");

            migrationBuilder.DropTable(
                name: "KisiIletisimBilgi");

            migrationBuilder.DropTable(
                name: "IletisimBilgiTipi");
        }
    }
}
