using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LifePlanner.Data.Migrations
{
    public partial class PrvaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admini",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admini", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NeregistrovaniKorisnici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeregistrovaniKorisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrovaniKorisnici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrovaniKorisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jela",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false),
                    Kategorija = table.Column<int>(nullable: false),
                    Sastojci = table.Column<string>(nullable: true),
                    KorisnikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jela_RegistrovaniKorisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "RegistrovaniKorisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KolicineVode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(nullable: false),
                    Kolicina = table.Column<decimal>(type: "decimal(2,2)", nullable: false),
                    KorisnikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KolicineVode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KolicineVode_RegistrovaniKorisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "RegistrovaniKorisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Raspolozenja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(nullable: false),
                    TipRaspolozenja = table.Column<int>(nullable: false),
                    KorisnikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raspolozenja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Raspolozenja_RegistrovaniKorisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "RegistrovaniKorisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taskovi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    KorisnikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taskovi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taskovi_RegistrovaniKorisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "RegistrovaniKorisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treninzi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false),
                    Vjezbe = table.Column<string>(nullable: true),
                    KorisnikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treninzi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treninzi_RegistrovaniKorisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "RegistrovaniKorisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jela_KorisnikID",
                table: "Jela",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_KolicineVode_KorisnikID",
                table: "KolicineVode",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Raspolozenja_KorisnikID",
                table: "Raspolozenja",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Taskovi_KorisnikID",
                table: "Taskovi",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Treninzi_KorisnikID",
                table: "Treninzi",
                column: "KorisnikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admini");

            migrationBuilder.DropTable(
                name: "Jela");

            migrationBuilder.DropTable(
                name: "KolicineVode");

            migrationBuilder.DropTable(
                name: "NeregistrovaniKorisnici");

            migrationBuilder.DropTable(
                name: "Raspolozenja");

            migrationBuilder.DropTable(
                name: "Taskovi");

            migrationBuilder.DropTable(
                name: "Treninzi");

            migrationBuilder.DropTable(
                name: "RegistrovaniKorisnici");
        }
    }
}
