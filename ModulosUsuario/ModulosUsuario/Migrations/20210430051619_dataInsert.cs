using Microsoft.EntityFrameworkCore.Migrations;

namespace ModulosUsuario.Migrations
{
    public partial class dataInsert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TransactionType",
                columns: new[] { "Description", "IsIncoming" },
                values: new object[,]
                {
                    { "Compra", true },
                    { "Venda", false },
                    { "Perda", false },
                    { "Furto", false },
                    { "Transferência para Filial", false },
                    { "Recebimento de Filial", true },
                    { "Ajuste de Entrada", true },
                    { "Ajuste de Saída", false },
                    { "Devolução", true },
                    { "Troca", false }
            });

            migrationBuilder.InsertData(
                table: "UnityType",
                columns: new[] { "Description" },
                values: new object[,]
                {
                    { "Litro" },
                    { "Mililitro" },
                    { "Grama" },
                    { "Quilo" },
                    { "Unidade" }
            });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
