using Microsoft.EntityFrameworkCore.Migrations;

namespace LifePlanner.Migrations
{
    public partial class FKCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jela_RegistrovaniKorisnici_KorisnikId",
                table: "Jela");

            migrationBuilder.DropForeignKey(
                name: "FK_KolicineVode_RegistrovaniKorisnici_KorisnikId",
                table: "KolicineVode");

            migrationBuilder.DropForeignKey(
                name: "FK_Raspolozenja_RegistrovaniKorisnici_KorisnikId",
                table: "Raspolozenja");

            migrationBuilder.DropForeignKey(
                name: "FK_Treninzi_RegistrovaniKorisnici_KorisnikId",
                table: "Treninzi");

            migrationBuilder.DropForeignKey(
                name: "FK_Zadaci_RegistrovaniKorisnici_KorisnikId",
                table: "Zadaci");

            migrationBuilder.AddForeignKey(
                name: "FK_Jela_RegistrovaniKorisnici_KorisnikId",
                table: "Jela",
                column: "KorisnikId",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KolicineVode_RegistrovaniKorisnici_KorisnikId",
                table: "KolicineVode",
                column: "KorisnikId",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Raspolozenja_RegistrovaniKorisnici_KorisnikId",
                table: "Raspolozenja",
                column: "KorisnikId",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treninzi_RegistrovaniKorisnici_KorisnikId",
                table: "Treninzi",
                column: "KorisnikId",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zadaci_RegistrovaniKorisnici_KorisnikId",
                table: "Zadaci",
                column: "KorisnikId",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jela_RegistrovaniKorisnici_KorisnikId",
                table: "Jela");

            migrationBuilder.DropForeignKey(
                name: "FK_KolicineVode_RegistrovaniKorisnici_KorisnikId",
                table: "KolicineVode");

            migrationBuilder.DropForeignKey(
                name: "FK_Raspolozenja_RegistrovaniKorisnici_KorisnikId",
                table: "Raspolozenja");

            migrationBuilder.DropForeignKey(
                name: "FK_Treninzi_RegistrovaniKorisnici_KorisnikId",
                table: "Treninzi");

            migrationBuilder.DropForeignKey(
                name: "FK_Zadaci_RegistrovaniKorisnici_KorisnikId",
                table: "Zadaci");

            migrationBuilder.AddForeignKey(
                name: "FK_Jela_RegistrovaniKorisnici_KorisnikId",
                table: "Jela",
                column: "KorisnikId",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KolicineVode_RegistrovaniKorisnici_KorisnikId",
                table: "KolicineVode",
                column: "KorisnikId",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Raspolozenja_RegistrovaniKorisnici_KorisnikId",
                table: "Raspolozenja",
                column: "KorisnikId",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Treninzi_RegistrovaniKorisnici_KorisnikId",
                table: "Treninzi",
                column: "KorisnikId",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zadaci_RegistrovaniKorisnici_KorisnikId",
                table: "Zadaci",
                column: "KorisnikId",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
