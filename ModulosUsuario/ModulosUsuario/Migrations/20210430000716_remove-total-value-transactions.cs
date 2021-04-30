using Microsoft.EntityFrameworkCore.Migrations;

namespace ModulosUsuario.Migrations
{
    public partial class removetotalvaluetransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalValue",
                table: "ToolsTransaction");

            migrationBuilder.DropColumn(
                name: "TotalValue",
                table: "ProductTransaction");

            migrationBuilder.DropColumn(
                name: "TotalValue",
                table: "MaterialTransaction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalValue",
                table: "ToolsTransaction",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalValue",
                table: "ProductTransaction",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalValue",
                table: "MaterialTransaction",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
