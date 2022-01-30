using Microsoft.EntityFrameworkCore.Migrations;

namespace assessment.report.db.Migrations
{
    public partial class AddDosyaYoluToRaporTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dosyayolu",
                table: "Rapor",
                newName: "DosyaYolu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DosyaYolu",
                table: "Rapor",
                newName: "Dosyayolu");
        }
    }
}
