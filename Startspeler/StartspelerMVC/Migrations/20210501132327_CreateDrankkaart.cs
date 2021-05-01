using Microsoft.EntityFrameworkCore.Migrations;

namespace StartspelerMVC.Migrations
{
    public partial class CreateDrankkaart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drankkaarten_User_UserId",
                schema: "SS",
                table: "Drankkaarten");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "SS",
                table: "Drankkaarten",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Drankkaarten_UserId",
                schema: "SS",
                table: "Drankkaarten",
                newName: "IX_Drankkaarten_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Drankkaarten_User_UserID",
                schema: "SS",
                table: "Drankkaarten",
                column: "UserID",
                principalSchema: "SS",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drankkaarten_User_UserID",
                schema: "SS",
                table: "Drankkaarten");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "SS",
                table: "Drankkaarten",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Drankkaarten_UserID",
                schema: "SS",
                table: "Drankkaarten",
                newName: "IX_Drankkaarten_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drankkaarten_User_UserId",
                schema: "SS",
                table: "Drankkaarten",
                column: "UserId",
                principalSchema: "SS",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
