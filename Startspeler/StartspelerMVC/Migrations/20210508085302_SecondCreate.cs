using Microsoft.EntityFrameworkCore.Migrations;

namespace StartspelerMVC.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bestellijnen",
                schema: "SS",
                columns: table => new
                {
                    BestellijnID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aantal = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestellijnen", x => x.BestellijnID);
                    table.ForeignKey(
                        name: "FK_Bestellijnen_Producten_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "SS",
                        principalTable: "Producten",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bestellijnen_ProductId",
                schema: "SS",
                table: "Bestellijnen",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bestellijnen",
                schema: "SS");
        }
    }
}
