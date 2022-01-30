using Microsoft.EntityFrameworkCore.Migrations;

namespace assessment.contact.db.Migrations
{
    public partial class AddKisiIdToKisiIletimiBilgiTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KisiId",
                table: "KisiIletisimBilgi",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_KisiIletisimBilgi_KisiId",
                table: "KisiIletisimBilgi",
                column: "KisiId");

            migrationBuilder.AddForeignKey(
                name: "FK_KisiIletisimBilgi_Kisi_KisiId",
                table: "KisiIletisimBilgi",
                column: "KisiId",
                principalTable: "Kisi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KisiIletisimBilgi_Kisi_KisiId",
                table: "KisiIletisimBilgi");

            migrationBuilder.DropIndex(
                name: "IX_KisiIletisimBilgi_KisiId",
                table: "KisiIletisimBilgi");

            migrationBuilder.DropColumn(
                name: "KisiId",
                table: "KisiIletisimBilgi");
        }
    }
}
