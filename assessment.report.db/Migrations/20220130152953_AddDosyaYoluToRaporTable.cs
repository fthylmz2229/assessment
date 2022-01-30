using Microsoft.EntityFrameworkCore.Migrations;

namespace assessment.report.db.Migrations
{
    public partial class AddDosyaYoluToRaporTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dosyayolu",
                table: "Rapor",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dosyayolu",
                table: "Rapor");
        }
    }
}
