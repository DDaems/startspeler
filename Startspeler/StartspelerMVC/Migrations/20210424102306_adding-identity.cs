using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StartspelerMVC.Migrations
{
    public partial class addingidentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestelling_User_UserID",
                schema: "SS",
                table: "Bestelling");

            migrationBuilder.DropForeignKey(
                name: "FK_Drankkaart_User_userID",
                schema: "SS",
                table: "Drankkaart");

            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijving_User_UserID",
                schema: "SS",
                table: "Inschrijving");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "SS",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "SS",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "SS",
                table: "Inschrijving",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Inschrijving_UserID",
                schema: "SS",
                table: "Inschrijving",
                newName: "IX_Inschrijving_UserId");

            migrationBuilder.RenameColumn(
                name: "userID",
                schema: "SS",
                table: "Drankkaart",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Drankkaart_userID",
                schema: "SS",
                table: "Drankkaart",
                newName: "IX_Drankkaart_UserId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "SS",
                table: "Bestelling",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bestelling_UserID",
                schema: "SS",
                table: "Bestelling",
                newName: "IX_Bestelling_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "SS",
                table: "User",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                schema: "SS",
                table: "User",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                schema: "SS",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "SS",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                schema: "SS",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                schema: "SS",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                schema: "SS",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                schema: "SS",
                table: "User",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                schema: "SS",
                table: "User",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                schema: "SS",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "SS",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                schema: "SS",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                schema: "SS",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                schema: "SS",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                schema: "SS",
                table: "User",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "SS",
                table: "Inschrijving",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "SS",
                table: "Drankkaart",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "SS",
                table: "Bestelling",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "SS",
                table: "User",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "SS",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "SS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "SS",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "SS",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "SS",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "SS",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "SS",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "SS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "SS",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "SS",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "SS",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "SS",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "SS",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "SS",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "SS",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "SS",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "SS",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "SS",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "SS",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bestelling_User_UserId",
                schema: "SS",
                table: "Bestelling",
                column: "UserId",
                principalSchema: "SS",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Drankkaart_User_UserId",
                schema: "SS",
                table: "Drankkaart",
                column: "UserId",
                principalSchema: "SS",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijving_User_UserId",
                schema: "SS",
                table: "Inschrijving",
                column: "UserId",
                principalSchema: "SS",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestelling_User_UserId",
                schema: "SS",
                table: "Bestelling");

            migrationBuilder.DropForeignKey(
                name: "FK_Drankkaart_User_UserId",
                schema: "SS",
                table: "Drankkaart");

            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijving_User_UserId",
                schema: "SS",
                table: "Inschrijving");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "SS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "SS",
                table: "User");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                schema: "SS",
                table: "User");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                schema: "SS",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "SS",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                schema: "SS",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "SS",
                table: "User");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                schema: "SS",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                schema: "SS",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                schema: "SS",
                table: "User");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                schema: "SS",
                table: "User");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                schema: "SS",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                schema: "SS",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "SS",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                schema: "SS",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                schema: "SS",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                schema: "SS",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserName",
                schema: "SS",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "SS",
                table: "Inschrijving",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Inschrijving_UserId",
                schema: "SS",
                table: "Inschrijving",
                newName: "IX_Inschrijving_UserID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "SS",
                table: "Drankkaart",
                newName: "userID");

            migrationBuilder.RenameIndex(
                name: "IX_Drankkaart_UserId",
                schema: "SS",
                table: "Drankkaart",
                newName: "IX_Drankkaart_userID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "SS",
                table: "Bestelling",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Bestelling_UserId",
                schema: "SS",
                table: "Bestelling",
                newName: "IX_Bestelling_UserID");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "SS",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                schema: "SS",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                schema: "SS",
                table: "Inschrijving",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userID",
                schema: "SS",
                table: "Drankkaart",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                schema: "SS",
                table: "Bestelling",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "SS",
                table: "User",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bestelling_User_UserID",
                schema: "SS",
                table: "Bestelling",
                column: "UserID",
                principalSchema: "SS",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drankkaart_User_userID",
                schema: "SS",
                table: "Drankkaart",
                column: "userID",
                principalSchema: "SS",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijving_User_UserID",
                schema: "SS",
                table: "Inschrijving",
                column: "UserID",
                principalSchema: "SS",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
