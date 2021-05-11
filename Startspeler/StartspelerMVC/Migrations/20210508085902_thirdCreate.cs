using Microsoft.EntityFrameworkCore.Migrations;

namespace StartspelerMVC.Migrations
{
    public partial class thirdCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestellingen_User_UserId1",
                schema: "SS",
                table: "Bestellingen");

            migrationBuilder.DropIndex(
                name: "IX_Bestellingen_UserId1",
                schema: "SS",
                table: "Bestellingen");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "SS",
                table: "Bestellingen");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "SS",
                table: "Bestellingen",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Bestellingen_UserId",
                schema: "SS",
                table: "Bestellingen",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bestellingen_User_UserId",
                schema: "SS",
                table: "Bestellingen",
                column: "UserId",
                principalSchema: "SS",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestellingen_User_UserId",
                schema: "SS",
                table: "Bestellingen");

            migrationBuilder.DropIndex(
                name: "IX_Bestellingen_UserId",
                schema: "SS",
                table: "Bestellingen");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "SS",
                table: "Bestellingen",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                schema: "SS",
                table: "Bestellingen",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bestellingen_UserId1",
                schema: "SS",
                table: "Bestellingen",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bestellingen_User_UserId1",
                schema: "SS",
                table: "Bestellingen",
                column: "UserId1",
                principalSchema: "SS",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
