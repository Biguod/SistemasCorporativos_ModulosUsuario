using Microsoft.EntityFrameworkCore.Migrations;

namespace ModulosUsuario.Migrations
{
    public partial class addedUserOnProductTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ProductTransaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransaction_UserId",
                table: "ProductTransaction",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTransaction_Users_UserId",
                table: "ProductTransaction",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTransaction_Users_UserId",
                table: "ProductTransaction");

            migrationBuilder.DropIndex(
                name: "IX_ProductTransaction_UserId",
                table: "ProductTransaction");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProductTransaction");
        }
    }
}
