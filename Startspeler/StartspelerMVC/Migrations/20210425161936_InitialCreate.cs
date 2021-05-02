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
                name: "Categorie",
                schema: "SS",
                columns: table => new
                {
                    CategorieID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.CategorieID);
                });

            migrationBuilder.CreateTable(
                name: "DrankkaartType",
                schema: "SS",
                columns: table => new
                {
                    DrankkaartTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grootte = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrankkaartType", x => x.DrankkaartTypeID);
                });

            migrationBuilder.CreateTable(
                name: "EvenementType",
                schema: "SS",
                columns: table => new
                {
                    EvenementTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvenementType", x => x.EvenementTypeID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "SS",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(nullable: true),
                    Achternaam = table.Column<string>(nullable: true),
                    Geboortedatum = table.Column<DateTime>(nullable: false),
                    Pincode = table.Column<int>(nullable: false),
                    token = table.Column<string>(nullable: true),
                    Admin = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
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
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalSchema: "SS",
                        principalTable: "Categorie",
                        principalColumn: "CategorieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evenement",
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
                    table.PrimaryKey("PK_Evenement", x => x.EvenementID);
                    table.ForeignKey(
                        name: "FK_Evenement_EvenementType_EvenementTypeID",
                        column: x => x.EvenementTypeID,
                        principalSchema: "SS",
                        principalTable: "EvenementType",
                        principalColumn: "EvenementTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drankkaart",
                schema: "SS",
                columns: table => new
                {
                    DrankkaartID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(nullable: false),
                    Aantal_Verbruikt = table.Column<int>(nullable: false),
                    DrankkaartTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drankkaart", x => x.DrankkaartID);
                    table.ForeignKey(
                        name: "FK_Drankkaart_DrankkaartType_DrankkaartTypeID",
                        column: x => x.DrankkaartTypeID,
                        principalSchema: "SS",
                        principalTable: "DrankkaartType",
                        principalColumn: "DrankkaartTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drankkaart_User_userID",
                        column: x => x.userID,
                        principalSchema: "SS",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bestelling",
                schema: "SS",
                columns: table => new
                {
                    BestellingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    Aantal = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestelling", x => x.BestellingID);
                    table.ForeignKey(
                        name: "FK_Bestelling_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "SS",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bestelling_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "SS",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inschrijving",
                schema: "SS",
                columns: table => new
                {
                    InschrijvingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvenementID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inschrijving", x => x.InschrijvingID);
                    table.ForeignKey(
                        name: "FK_Inschrijving_Evenement_EvenementID",
                        column: x => x.EvenementID,
                        principalSchema: "SS",
                        principalTable: "Evenement",
                        principalColumn: "EvenementID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inschrijving_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "SS",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bestelling_ProductID",
                schema: "SS",
                table: "Bestelling",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Bestelling_UserID",
                schema: "SS",
                table: "Bestelling",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Drankkaart_DrankkaartTypeID",
                schema: "SS",
                table: "Drankkaart",
                column: "DrankkaartTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Drankkaart_userID",
                schema: "SS",
                table: "Drankkaart",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Evenement_EvenementTypeID",
                schema: "SS",
                table: "Evenement",
                column: "EvenementTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijving_EvenementID",
                schema: "SS",
                table: "Inschrijving",
                column: "EvenementID");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijving_UserID",
                schema: "SS",
                table: "Inschrijving",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategorieID",
                schema: "SS",
                table: "Product",
                column: "CategorieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bestelling",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "Drankkaart",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "Inschrijving",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "DrankkaartType",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "Evenement",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "User",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "Categorie",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "EvenementType",
                schema: "SS");
        }
    }
}
