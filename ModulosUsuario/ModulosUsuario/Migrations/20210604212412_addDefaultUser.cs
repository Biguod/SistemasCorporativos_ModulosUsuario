using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ModulosUsuario.Migrations
{
    public partial class addDefaultUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
