using Microsoft.EntityFrameworkCore.Migrations;

namespace ModulosUsuario.Migrations
{
    public partial class addincomingflagtransactiontype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsIncoming",
                table: "TransactionType",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsIncoming",
                table: "TransactionType");
        }
    }
}
