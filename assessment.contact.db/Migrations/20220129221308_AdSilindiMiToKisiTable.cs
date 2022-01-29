using Microsoft.EntityFrameworkCore.Migrations;

namespace assessment.contact.db.Migrations
{
    public partial class AdSilindiMiToKisiTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SilindiMi",
                table: "Kisi",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SilindiMi",
                table: "Kisi");
        }
    }
}
