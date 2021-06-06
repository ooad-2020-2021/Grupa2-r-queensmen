using Microsoft.EntityFrameworkCore.Migrations;

namespace LifePlanner.Migrations
{
    public partial class povecanaKolicinaVode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Kolicina",
                table: "KolicineVode",
                type: "decimal(7,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Kolicina",
                table: "KolicineVode",
                type: "decimal(2,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)");
        }
    }
}
