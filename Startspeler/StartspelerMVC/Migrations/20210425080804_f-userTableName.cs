using Microsoft.EntityFrameworkCore.Migrations;

namespace StartspelerMVC.Migrations
{
    public partial class fuserTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestellingen_AspNetUsers_UserId",
                schema: "SS",
                table: "Bestellingen");

            migrationBuilder.DropForeignKey(
                name: "FK_Drankkaarten_AspNetUsers_UserId",
                schema: "SS",
                table: "Drankkaarten");

            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijvingen_AspNetUsers_UserId",
                schema: "SS",
                table: "Inschrijvingen");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_AspNetUsers_UserId",
                schema: "SS",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_AspNetUsers_UserId",
                schema: "SS",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_AspNetUsers_UserId",
                schema: "SS",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_AspNetUsers_UserId",
                schema: "SS",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                schema: "SS",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "SS",
                newName: "User",
                newSchema: "SS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "SS",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bestellingen_User_UserId",
                schema: "SS",
                table: "Bestellingen",
                column: "UserId",
                principalSchema: "SS",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Drankkaarten_User_UserId",
                schema: "SS",
                table: "Drankkaarten",
                column: "UserId",
                principalSchema: "SS",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijvingen_User_UserId",
                schema: "SS",
                table: "Inschrijvingen",
                column: "UserId",
                principalSchema: "SS",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_User_UserId",
                schema: "SS",
                table: "UserClaims",
                column: "UserId",
                principalSchema: "SS",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_User_UserId",
                schema: "SS",
                table: "UserLogins",
                column: "UserId",
                principalSchema: "SS",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_User_UserId",
                schema: "SS",
                table: "UserRoles",
                column: "UserId",
                principalSchema: "SS",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_User_UserId",
                schema: "SS",
                table: "UserTokens",
                column: "UserId",
                principalSchema: "SS",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestellingen_User_UserId",
                schema: "SS",
                table: "Bestellingen");

            migrationBuilder.DropForeignKey(
                name: "FK_Drankkaarten_User_UserId",
                schema: "SS",
                table: "Drankkaarten");

            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijvingen_User_UserId",
                schema: "SS",
                table: "Inschrijvingen");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_User_UserId",
                schema: "SS",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_User_UserId",
                schema: "SS",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_User_UserId",
                schema: "SS",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_User_UserId",
                schema: "SS",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "SS",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "SS",
                newName: "AspNetUsers",
                newSchema: "SS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                schema: "SS",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bestellingen_AspNetUsers_UserId",
                schema: "SS",
                table: "Bestellingen",
                column: "UserId",
                principalSchema: "SS",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Drankkaarten_AspNetUsers_UserId",
                schema: "SS",
                table: "Drankkaarten",
                column: "UserId",
                principalSchema: "SS",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijvingen_AspNetUsers_UserId",
                schema: "SS",
                table: "Inschrijvingen",
                column: "UserId",
                principalSchema: "SS",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_AspNetUsers_UserId",
                schema: "SS",
                table: "UserClaims",
                column: "UserId",
                principalSchema: "SS",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_AspNetUsers_UserId",
                schema: "SS",
                table: "UserLogins",
                column: "UserId",
                principalSchema: "SS",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_AspNetUsers_UserId",
                schema: "SS",
                table: "UserRoles",
                column: "UserId",
                principalSchema: "SS",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_AspNetUsers_UserId",
                schema: "SS",
                table: "UserTokens",
                column: "UserId",
                principalSchema: "SS",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
