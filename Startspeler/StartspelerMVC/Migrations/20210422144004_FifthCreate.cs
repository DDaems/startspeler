using Microsoft.EntityFrameworkCore.Migrations;

namespace StartspelerMVC.Migrations
{
    public partial class FifthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BestellingID",
                schema: "SS",
                table: "Bestellijn");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                schema: "SS",
                table: "Bestellijn",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Bestellijn_ProductID",
                schema: "SS",
                table: "Bestellijn",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bestellijn_Product_ProductID",
                schema: "SS",
                table: "Bestellijn",
                column: "ProductID",
                principalSchema: "SS",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestellijn_Product_ProductID",
                schema: "SS",
                table: "Bestellijn");

            migrationBuilder.DropIndex(
                name: "IX_Bestellijn_ProductID",
                schema: "SS",
                table: "Bestellijn");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                schema: "SS",
                table: "Bestellijn",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BestellingID",
                schema: "SS",
                table: "Bestellijn",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
