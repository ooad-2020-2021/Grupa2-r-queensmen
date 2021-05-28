using Microsoft.EntityFrameworkCore.Migrations;

namespace LifePlanner.Migrations
{
    public partial class nonReqFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jela_RegistrovaniKorisnici_KorisnikId1",
                table: "Jela");

            migrationBuilder.DropForeignKey(
                name: "FK_KolicineVode_RegistrovaniKorisnici_KorisnikId1",
                table: "KolicineVode");

            migrationBuilder.DropForeignKey(
                name: "FK_Raspolozenja_RegistrovaniKorisnici_KorisnikId1",
                table: "Raspolozenja");

            migrationBuilder.DropForeignKey(
                name: "FK_Treninzi_RegistrovaniKorisnici_KorisnikId1",
                table: "Treninzi");

            migrationBuilder.DropForeignKey(
                name: "FK_Zadaci_RegistrovaniKorisnici_KorisnikId1",
                table: "Zadaci");

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikId1",
                table: "Zadaci",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikId1",
                table: "Treninzi",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikId1",
                table: "Raspolozenja",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikId1",
                table: "KolicineVode",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikId1",
                table: "Jela",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Jela_RegistrovaniKorisnici_KorisnikId1",
                table: "Jela",
                column: "KorisnikId1",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KolicineVode_RegistrovaniKorisnici_KorisnikId1",
                table: "KolicineVode",
                column: "KorisnikId1",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Raspolozenja_RegistrovaniKorisnici_KorisnikId1",
                table: "Raspolozenja",
                column: "KorisnikId1",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Treninzi_RegistrovaniKorisnici_KorisnikId1",
                table: "Treninzi",
                column: "KorisnikId1",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zadaci_RegistrovaniKorisnici_KorisnikId1",
                table: "Zadaci",
                column: "KorisnikId1",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jela_RegistrovaniKorisnici_KorisnikId1",
                table: "Jela");

            migrationBuilder.DropForeignKey(
                name: "FK_KolicineVode_RegistrovaniKorisnici_KorisnikId1",
                table: "KolicineVode");

            migrationBuilder.DropForeignKey(
                name: "FK_Raspolozenja_RegistrovaniKorisnici_KorisnikId1",
                table: "Raspolozenja");

            migrationBuilder.DropForeignKey(
                name: "FK_Treninzi_RegistrovaniKorisnici_KorisnikId1",
                table: "Treninzi");

            migrationBuilder.DropForeignKey(
                name: "FK_Zadaci_RegistrovaniKorisnici_KorisnikId1",
                table: "Zadaci");

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikId1",
                table: "Zadaci",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikId1",
                table: "Treninzi",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikId1",
                table: "Raspolozenja",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikId1",
                table: "KolicineVode",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikId1",
                table: "Jela",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Jela_RegistrovaniKorisnici_KorisnikId1",
                table: "Jela",
                column: "KorisnikId1",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KolicineVode_RegistrovaniKorisnici_KorisnikId1",
                table: "KolicineVode",
                column: "KorisnikId1",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Raspolozenja_RegistrovaniKorisnici_KorisnikId1",
                table: "Raspolozenja",
                column: "KorisnikId1",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treninzi_RegistrovaniKorisnici_KorisnikId1",
                table: "Treninzi",
                column: "KorisnikId1",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zadaci_RegistrovaniKorisnici_KorisnikId1",
                table: "Zadaci",
                column: "KorisnikId1",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
