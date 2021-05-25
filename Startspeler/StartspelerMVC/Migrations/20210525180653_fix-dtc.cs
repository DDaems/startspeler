using Microsoft.EntityFrameworkCore.Migrations;

namespace StartspelerMVC.Migrations
{
    public partial class fixdtc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drankkaarten_DrankkaartTypes_DrankkaartTypeID",
                schema: "SS",
                table: "Drankkaarten");

            migrationBuilder.AlterColumn<int>(
                name: "DrankkaartTypeID",
                schema: "SS",
                table: "Drankkaarten",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Drankkaarten_DrankkaartTypes_DrankkaartTypeID",
                schema: "SS",
                table: "Drankkaarten",
                column: "DrankkaartTypeID",
                principalSchema: "SS",
                principalTable: "DrankkaartTypes",
                principalColumn: "DrankkaartTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drankkaarten_DrankkaartTypes_DrankkaartTypeID",
                schema: "SS",
                table: "Drankkaarten");

            migrationBuilder.AlterColumn<int>(
                name: "DrankkaartTypeID",
                schema: "SS",
                table: "Drankkaarten",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Drankkaarten_DrankkaartTypes_DrankkaartTypeID",
                schema: "SS",
                table: "Drankkaarten",
                column: "DrankkaartTypeID",
                principalSchema: "SS",
                principalTable: "DrankkaartTypes",
                principalColumn: "DrankkaartTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
