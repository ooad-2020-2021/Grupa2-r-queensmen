using Microsoft.EntityFrameworkCore.Migrations;

namespace LifePlanner.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_RegistrovaniKorisnici_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_RegistrovaniKorisnici_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_RegistrovaniKorisnici_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_RegistrovaniKorisnici_UserId",
                table: "AspNetUserTokens");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegistrovaniKorisnici",
                table: "RegistrovaniKorisnici");

            migrationBuilder.RenameTable(
                name: "RegistrovaniKorisnici",
                newName: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Prezime",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jela_AspNetUsers_KorisnikId1",
                table: "Jela",
                column: "KorisnikId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KolicineVode_AspNetUsers_KorisnikId1",
                table: "KolicineVode",
                column: "KorisnikId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Raspolozenja_AspNetUsers_KorisnikId1",
                table: "Raspolozenja",
                column: "KorisnikId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treninzi_AspNetUsers_KorisnikId1",
                table: "Treninzi",
                column: "KorisnikId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zadaci_AspNetUsers_KorisnikId1",
                table: "Zadaci",
                column: "KorisnikId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Jela_AspNetUsers_KorisnikId1",
                table: "Jela");

            migrationBuilder.DropForeignKey(
                name: "FK_KolicineVode_AspNetUsers_KorisnikId1",
                table: "KolicineVode");

            migrationBuilder.DropForeignKey(
                name: "FK_Raspolozenja_AspNetUsers_KorisnikId1",
                table: "Raspolozenja");

            migrationBuilder.DropForeignKey(
                name: "FK_Treninzi_AspNetUsers_KorisnikId1",
                table: "Treninzi");

            migrationBuilder.DropForeignKey(
                name: "FK_Zadaci_AspNetUsers_KorisnikId1",
                table: "Zadaci");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "RegistrovaniKorisnici");

            migrationBuilder.AlterColumn<string>(
                name: "Prezime",
                table: "RegistrovaniKorisnici",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "RegistrovaniKorisnici",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistrovaniKorisnici",
                table: "RegistrovaniKorisnici",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_RegistrovaniKorisnici_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_RegistrovaniKorisnici_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_RegistrovaniKorisnici_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_RegistrovaniKorisnici_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "RegistrovaniKorisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
