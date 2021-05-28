using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LifePlanner.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NeregistrovaniKorisnici",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeregistrovaniKorisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrovaniKorisnici",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrovaniKorisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_RegistrovaniKorisnici_UserId",
                        column: x => x.UserId,
                        principalTable: "RegistrovaniKorisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_RegistrovaniKorisnici_UserId",
                        column: x => x.UserId,
                        principalTable: "RegistrovaniKorisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_RegistrovaniKorisnici_UserId",
                        column: x => x.UserId,
                        principalTable: "RegistrovaniKorisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_RegistrovaniKorisnici_UserId",
                        column: x => x.UserId,
                        principalTable: "RegistrovaniKorisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jela",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Naziv = table.Column<string>(nullable: false),
                    Kategorija = table.Column<int>(nullable: false),
                    Sastojci = table.Column<string>(nullable: true),
                    KorisnikId1 = table.Column<string>(nullable: false),
                    KorisnikId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jela_RegistrovaniKorisnici_KorisnikId1",
                        column: x => x.KorisnikId1,
                        principalTable: "RegistrovaniKorisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KolicineVode",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    Kolicina = table.Column<decimal>(type: "decimal(2,2)", nullable: false),
                    KorisnikId1 = table.Column<string>(nullable: false),
                    KorisnikId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KolicineVode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KolicineVode_RegistrovaniKorisnici_KorisnikId1",
                        column: x => x.KorisnikId1,
                        principalTable: "RegistrovaniKorisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Raspolozenja",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    TipRaspolozenja = table.Column<int>(nullable: false),
                    KorisnikId1 = table.Column<string>(nullable: false),
                    KorisnikId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raspolozenja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Raspolozenja_RegistrovaniKorisnici_KorisnikId1",
                        column: x => x.KorisnikId1,
                        principalTable: "RegistrovaniKorisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treninzi",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Naziv = table.Column<string>(nullable: false),
                    Vjezbe = table.Column<string>(nullable: true),
                    KorisnikId1 = table.Column<string>(nullable: false),
                    KorisnikId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treninzi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treninzi_RegistrovaniKorisnici_KorisnikId1",
                        column: x => x.KorisnikId1,
                        principalTable: "RegistrovaniKorisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zadaci",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Naziv = table.Column<string>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    KorisnikId1 = table.Column<string>(nullable: false),
                    KorisnikId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zadaci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zadaci_RegistrovaniKorisnici_KorisnikId1",
                        column: x => x.KorisnikId1,
                        principalTable: "RegistrovaniKorisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Jela_KorisnikId1",
                table: "Jela",
                column: "KorisnikId1");

            migrationBuilder.CreateIndex(
                name: "IX_KolicineVode_KorisnikId1",
                table: "KolicineVode",
                column: "KorisnikId1");

            migrationBuilder.CreateIndex(
                name: "IX_Raspolozenja_KorisnikId1",
                table: "Raspolozenja",
                column: "KorisnikId1");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "RegistrovaniKorisnici",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "RegistrovaniKorisnici",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Treninzi_KorisnikId1",
                table: "Treninzi",
                column: "KorisnikId1");

            migrationBuilder.CreateIndex(
                name: "IX_Zadaci_KorisnikId1",
                table: "Zadaci",
                column: "KorisnikId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Jela");

            migrationBuilder.DropTable(
                name: "KolicineVode");

            migrationBuilder.DropTable(
                name: "NeregistrovaniKorisnici");

            migrationBuilder.DropTable(
                name: "Raspolozenja");

            migrationBuilder.DropTable(
                name: "Treninzi");

            migrationBuilder.DropTable(
                name: "Zadaci");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "RegistrovaniKorisnici");
        }
    }
}
