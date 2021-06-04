using Microsoft.EntityFrameworkCore.Migrations;

namespace ModulosUsuario.Migrations
{
    public partial class addReserveTransactionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "TransactionType",
            columns: new[] { "Description", "IsIncoming" },
            values: new object[,]
            {
                { "Reserva", false }
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
