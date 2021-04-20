using Microsoft.EntityFrameworkCore.Migrations;

namespace StartspelerMVC.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bestelling",
                schema: "SS",
                columns: table => new
                {
                    BestellingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestelling", x => x.BestellingID);
                    table.ForeignKey(
                        name: "FK_Bestelling_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "SS",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categorie",
                schema: "SS",
                columns: table => new
                {
                    CategorieID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<int>(nullable: false)
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
                name: "Product",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "DrankkaartType",
                schema: "SS");

            migrationBuilder.DropTable(
                name: "Categorie",
                schema: "SS");
        }
    }
}
