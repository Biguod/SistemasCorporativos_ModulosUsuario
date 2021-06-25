using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ModulosUsuario.Migrations
{
    public partial class dataLoad : Migration
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
                    { "Troca", false },
                    { "Reserva", false },
                    { "Reserva Cancelada", true }
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

            migrationBuilder.InsertData(
               table: "UnityType",
               columns: new[] { "Description" },
               values: new object[,]
               {
                    { "Toneladas" }
               });

           migrationBuilder.InsertData(
               table: "Users",
               columns: new[] { "Login", "Password", "Email", "Name", "LastName", "BirthDate", "CPF", "Phone" },
               values: new object[,]
               {
                    { "System", "System", "system@email.com", "System", "System", DateTime.Now, "57707526023", "99999999999" }
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
