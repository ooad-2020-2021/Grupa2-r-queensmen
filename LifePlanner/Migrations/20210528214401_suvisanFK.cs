using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LifePlanner.Migrations
{
    public partial class suvisanFK : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_Zadaci_KorisnikId1",
                table: "Zadaci");

            migrationBuilder.DropIndex(
                name: "IX_Treninzi_KorisnikId1",
                table: "Treninzi");

            migrationBuilder.DropIndex(
                name: "IX_Raspolozenja_KorisnikId1",
                table: "Raspolozenja");

            migrationBuilder.DropIndex(
                name: "IX_KolicineVode_KorisnikId1",
                table: "KolicineVode");

            migrationBuilder.DropIndex(
                name: "IX_Jela_KorisnikId1",
                table: "Jela");

            migrationBuilder.DropColumn(
                name: "KorisnikId1",
                table: "Zadaci");

            migrationBuilder.DropColumn(
                name: "KorisnikId1",
                table: "Treninzi");

            migrationBuilder.DropColumn(
                name: "KorisnikId1",
                table: "Raspolozenja");

            migrationBuilder.DropColumn(
                name: "KorisnikId1",
                table: "KolicineVode");

            migrationBuilder.DropColumn(
                name: "KorisnikId1",
                table: "Jela");

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikId",
                table: "Zadaci",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikId",
                table: "Treninzi",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikId",
                table: "Raspolozenja",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikId",
                table: "KolicineVode",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "KorisnikId",
                table: "Jela",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Zadaci_KorisnikId",
                table: "Zadaci",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Treninzi_KorisnikId",
                table: "Treninzi",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Raspolozenja_KorisnikId",
                table: "Raspolozenja",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KolicineVode_KorisnikId",
                table: "KolicineVode",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Jela_KorisnikId",
                table: "Jela",
                column: "KorisnikId");

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

            migrationBuilder.DropIndex(
                name: "IX_Zadaci_KorisnikId",
                table: "Zadaci");

            migrationBuilder.DropIndex(
                name: "IX_Treninzi_KorisnikId",
                table: "Treninzi");

            migrationBuilder.DropIndex(
                name: "IX_Raspolozenja_KorisnikId",
                table: "Raspolozenja");

            migrationBuilder.DropIndex(
                name: "IX_KolicineVode_KorisnikId",
                table: "KolicineVode");

            migrationBuilder.DropIndex(
                name: "IX_Jela_KorisnikId",
                table: "Jela");

            migrationBuilder.AlterColumn<Guid>(
                name: "KorisnikId",
                table: "Zadaci",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KorisnikId1",
                table: "Zadaci",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "KorisnikId",
                table: "Treninzi",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KorisnikId1",
                table: "Treninzi",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "KorisnikId",
                table: "Raspolozenja",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KorisnikId1",
                table: "Raspolozenja",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "KorisnikId",
                table: "KolicineVode",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KorisnikId1",
                table: "KolicineVode",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "KorisnikId",
                table: "Jela",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KorisnikId1",
                table: "Jela",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zadaci_KorisnikId1",
                table: "Zadaci",
                column: "KorisnikId1");

            migrationBuilder.CreateIndex(
                name: "IX_Treninzi_KorisnikId1",
                table: "Treninzi",
                column: "KorisnikId1");

            migrationBuilder.CreateIndex(
                name: "IX_Raspolozenja_KorisnikId1",
                table: "Raspolozenja",
                column: "KorisnikId1");

            migrationBuilder.CreateIndex(
                name: "IX_KolicineVode_KorisnikId1",
                table: "KolicineVode",
                column: "KorisnikId1");

            migrationBuilder.CreateIndex(
                name: "IX_Jela_KorisnikId1",
                table: "Jela",
                column: "KorisnikId1");

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
    }
}
