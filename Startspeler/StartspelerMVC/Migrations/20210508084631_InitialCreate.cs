using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StartspelerMVC.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SS");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "SS",
                columns: table => new
                {
                    CategorieID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategorieID);
                });

            migrationBuilder.CreateTable(
                name: "DrankkaartTypes",
                schema: "SS",
                columns: table => new
                {
                    DrankkaartTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grootte = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrankkaartTypes", x => x.DrankkaartTypeID);
                });

            migrationBuilder.CreateTable(
                name: "EvenementTypes",
                schema: "SS",
                columns: table => new
                {
                    EvenementTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvenementTypes", x => x.EvenementTypeID);
                });

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
                name: "User",
                schema: "SS",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Voornaam = table.Column<string>(nullable: false),
                    Achternaam = table.Column<string>(nullable: false),
                    Geboortedatum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producten",
                schema: "SS",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    Prijs = table.Column<float>(nullable: false),
                    Ijskast = table.Column<int>(nullable: false),
                    OverigeStock = table.Column<int>(nullable: false),
                    CategorieID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producten", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Producten_Categories_CategorieID",
                        column: x => x.CategorieID,
                        principalSchema: "SS",
                        principalTable: "Categories",
                        principalColumn: "CategorieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evenementen",
                schema: "SS",
                columns: table => new
                {
                    EvenementID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(nullable: true),
                    Startdatum = table.Column<DateTime>(nullable: false),
                    Beschrijving = table.Column<string>(nullable: true),
                    Kostprijs = table.Column<float>(nullable: false),
                    Max_Deelnemers = table.Column<int>(nullable: false),
                    Einddatum = table.Column<DateTime>(nullable: false),
                    EvenementTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evenementen", x => x.EvenementID);
                    table.ForeignKey(
                        name: "FK_Evenementen_EvenementTypes_EvenementTypeID",
                        column: x => x.EvenementTypeID,
                        principalSchema: "SS",
                        principalTable: "EvenementTypes",
                        principalColumn: "EvenementTypeID",
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
                name: "Bestellingen",
                schema: "SS",
                columns: table => new
                {
                    BestellingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestellingen", x => x.BestellingID);
                    table.ForeignKey(
                        name: "FK_Bestellingen_User_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "SS",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Drankkaarten",
                schema: "SS",
                columns: table => new
                {
                    DrankkaartID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Aantal_beschikbaar = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Aankoopdatum = table.Column<DateTime>(nullable: false),
                    DrankkaartTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drankkaarten", x => x.DrankkaartID);
                    table.ForeignKey(
                        name: "FK_Drankkaarten_DrankkaartTypes_DrankkaartTypeID",
                        column: x => x.DrankkaartTypeID,
                        principalSchema: "SS",
                        principalTable: "DrankkaartTypes",
                        principalColumn: "DrankkaartTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drankkaarten_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "SS",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Inschrijvingen",
                schema: "SS",
                columns: table => new
                {
                    InschrijvingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvenementID = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inschrijvingen", x => x.InschrijvingID);
                    table.ForeignKey(
                        name: "FK_Inschrijvingen_Evenementen_EvenementID",
                        column: x => x.EvenementID,
                        principalSchema: "SS",
                        principalTable: "Evenementen",
                        principalColumn: "EvenementID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inschrijvingen_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "SS",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bestellingen_UserId1",
                schema: "SS",
                table: "Bestellingen",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Drankkaarten_DrankkaartTypeID",
                schema: "SS",
                table: "Drankkaarten",
                column: "DrankkaartTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Drankkaarten_UserId",
                schema: "SS",
                table: "Drankkaarten",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Evenementen_EvenementTypeID",
                schema: "SS",
                table: "Evenementen",
                column: "EvenementTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijvingen_EvenementID",
                schema: "SS",
                table: "Inschrijvingen",
                column: "EvenementID");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijvingen_UserId",
                schema: "SS",
                table: "Inschrijvingen",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Producten_CategorieID",
                schema: "SS",
                table: "Producten",
                column: "CategorieID");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bestellingen",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "Drankkaarten",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "Inschrijvingen",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "Producten",
                schema: "SS");

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
                name: "DrankkaartTypes",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "Evenementen",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "User",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "EvenementTypes",
                schema: "SS");
        }
    }
}
