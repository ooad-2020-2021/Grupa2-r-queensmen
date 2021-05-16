using Microsoft.EntityFrameworkCore.Migrations;

namespace LifePlanner.Data.Migrations
{
    public partial class TaskUZadatakNaBazi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taskovi_RegistrovaniKorisnici_KorisnikID",
                table: "Taskovi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Taskovi",
                table: "Taskovi");

            migrationBuilder.RenameTable(
                name: "Taskovi",
                newName: "Zadaci");

            migrationBuilder.RenameIndex(
                name: "IX_Taskovi_KorisnikID",
                table: "Zadaci",
                newName: "IX_Zadaci_KorisnikID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zadaci",
                table: "Zadaci",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Zadaci_RegistrovaniKorisnici_KorisnikID",
                table: "Zadaci",
                column: "KorisnikID",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zadaci_RegistrovaniKorisnici_KorisnikID",
                table: "Zadaci");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Zadaci",
                table: "Zadaci");

            migrationBuilder.RenameTable(
                name: "Zadaci",
                newName: "Taskovi");

            migrationBuilder.RenameIndex(
                name: "IX_Zadaci_KorisnikID",
                table: "Taskovi",
                newName: "IX_Taskovi_KorisnikID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Taskovi",
                table: "Taskovi",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Taskovi_RegistrovaniKorisnici_KorisnikID",
                table: "Taskovi",
                column: "KorisnikID",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
