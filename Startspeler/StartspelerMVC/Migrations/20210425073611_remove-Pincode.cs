using Microsoft.EntityFrameworkCore.Migrations;

namespace StartspelerMVC.Migrations
{
    public partial class removePincode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestelling_User_UserId",
                schema: "SS",
                table: "Bestelling");

            migrationBuilder.DropForeignKey(
                name: "FK_Drankkaart_DrankkaartType_DrankkaartTypeID",
                schema: "SS",
                table: "Drankkaart");

            migrationBuilder.DropForeignKey(
                name: "FK_Drankkaart_User_UserId",
                schema: "SS",
                table: "Drankkaart");

            migrationBuilder.DropForeignKey(
                name: "FK_Evenement_EvenementType_EvenementTypeID",
                schema: "SS",
                table: "Evenement");

            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijving_Evenement_EvenementID",
                schema: "SS",
                table: "Inschrijving");

            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijving_User_UserId",
                schema: "SS",
                table: "Inschrijving");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categorie_CategorieID",
                schema: "SS",
                table: "Product");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                schema: "SS",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inschrijving",
                schema: "SS",
                table: "Inschrijving");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EvenementType",
                schema: "SS",
                table: "EvenementType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Evenement",
                schema: "SS",
                table: "Evenement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DrankkaartType",
                schema: "SS",
                table: "DrankkaartType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drankkaart",
                schema: "SS",
                table: "Drankkaart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorie",
                schema: "SS",
                table: "Categorie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bestelling",
                schema: "SS",
                table: "Bestelling");

            migrationBuilder.DropColumn(
                name: "Pincode",
                schema: "SS",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "SS",
                newName: "AspNetUsers",
                newSchema: "SS");

            migrationBuilder.RenameTable(
                name: "Product",
                schema: "SS",
                newName: "Producten",
                newSchema: "SS");

            migrationBuilder.RenameTable(
                name: "Inschrijving",
                schema: "SS",
                newName: "Inschrijvingen",
                newSchema: "SS");

            migrationBuilder.RenameTable(
                name: "EvenementType",
                schema: "SS",
                newName: "EvenementTypes",
                newSchema: "SS");

            migrationBuilder.RenameTable(
                name: "Evenement",
                schema: "SS",
                newName: "Evenementen",
                newSchema: "SS");

            migrationBuilder.RenameTable(
                name: "DrankkaartType",
                schema: "SS",
                newName: "DrankkaartTypes",
                newSchema: "SS");

            migrationBuilder.RenameTable(
                name: "Drankkaart",
                schema: "SS",
                newName: "Drankkaarten",
                newSchema: "SS");

            migrationBuilder.RenameTable(
                name: "Categorie",
                schema: "SS",
                newName: "Categories",
                newSchema: "SS");

            migrationBuilder.RenameTable(
                name: "Bestelling",
                schema: "SS",
                newName: "Bestellingen",
                newSchema: "SS");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategorieID",
                schema: "SS",
                table: "Producten",
                newName: "IX_Producten_CategorieID");

            migrationBuilder.RenameIndex(
                name: "IX_Inschrijving_UserId",
                schema: "SS",
                table: "Inschrijvingen",
                newName: "IX_Inschrijvingen_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Inschrijving_EvenementID",
                schema: "SS",
                table: "Inschrijvingen",
                newName: "IX_Inschrijvingen_EvenementID");

            migrationBuilder.RenameIndex(
                name: "IX_Evenement_EvenementTypeID",
                schema: "SS",
                table: "Evenementen",
                newName: "IX_Evenementen_EvenementTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Drankkaart_UserId",
                schema: "SS",
                table: "Drankkaarten",
                newName: "IX_Drankkaarten_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Drankkaart_DrankkaartTypeID",
                schema: "SS",
                table: "Drankkaarten",
                newName: "IX_Drankkaarten_DrankkaartTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Bestelling_UserId",
                schema: "SS",
                table: "Bestellingen",
                newName: "IX_Bestellingen_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "token",
                schema: "SS",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Voornaam",
                schema: "SS",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Achternaam",
                schema: "SS",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                schema: "SS",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                schema: "SS",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producten",
                schema: "SS",
                table: "Producten",
                column: "ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inschrijvingen",
                schema: "SS",
                table: "Inschrijvingen",
                column: "InschrijvingID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EvenementTypes",
                schema: "SS",
                table: "EvenementTypes",
                column: "EvenementTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Evenementen",
                schema: "SS",
                table: "Evenementen",
                column: "EvenementID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DrankkaartTypes",
                schema: "SS",
                table: "DrankkaartTypes",
                column: "DrankkaartTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drankkaarten",
                schema: "SS",
                table: "Drankkaarten",
                column: "DrankkaartID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                schema: "SS",
                table: "Categories",
                column: "CategorieID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bestellingen",
                schema: "SS",
                table: "Bestellingen",
                column: "BestellingID");

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
                name: "FK_Drankkaarten_DrankkaartTypes_DrankkaartTypeID",
                schema: "SS",
                table: "Drankkaarten",
                column: "DrankkaartTypeID",
                principalSchema: "SS",
                principalTable: "DrankkaartTypes",
                principalColumn: "DrankkaartTypeID",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Evenementen_EvenementTypes_EvenementTypeID",
                schema: "SS",
                table: "Evenementen",
                column: "EvenementTypeID",
                principalSchema: "SS",
                principalTable: "EvenementTypes",
                principalColumn: "EvenementTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijvingen_Evenementen_EvenementID",
                schema: "SS",
                table: "Inschrijvingen",
                column: "EvenementID",
                principalSchema: "SS",
                principalTable: "Evenementen",
                principalColumn: "EvenementID",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Producten_Categories_CategorieID",
                schema: "SS",
                table: "Producten",
                column: "CategorieID",
                principalSchema: "SS",
                principalTable: "Categories",
                principalColumn: "CategorieID",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bestellingen_AspNetUsers_UserId",
                schema: "SS",
                table: "Bestellingen");

            migrationBuilder.DropForeignKey(
                name: "FK_Drankkaarten_DrankkaartTypes_DrankkaartTypeID",
                schema: "SS",
                table: "Drankkaarten");

            migrationBuilder.DropForeignKey(
                name: "FK_Drankkaarten_AspNetUsers_UserId",
                schema: "SS",
                table: "Drankkaarten");

            migrationBuilder.DropForeignKey(
                name: "FK_Evenementen_EvenementTypes_EvenementTypeID",
                schema: "SS",
                table: "Evenementen");

            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijvingen_Evenementen_EvenementID",
                schema: "SS",
                table: "Inschrijvingen");

            migrationBuilder.DropForeignKey(
                name: "FK_Inschrijvingen_AspNetUsers_UserId",
                schema: "SS",
                table: "Inschrijvingen");

            migrationBuilder.DropForeignKey(
                name: "FK_Producten_Categories_CategorieID",
                schema: "SS",
                table: "Producten");

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
                name: "PK_Producten",
                schema: "SS",
                table: "Producten");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inschrijvingen",
                schema: "SS",
                table: "Inschrijvingen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EvenementTypes",
                schema: "SS",
                table: "EvenementTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Evenementen",
                schema: "SS",
                table: "Evenementen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DrankkaartTypes",
                schema: "SS",
                table: "DrankkaartTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drankkaarten",
                schema: "SS",
                table: "Drankkaarten");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                schema: "SS",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bestellingen",
                schema: "SS",
                table: "Bestellingen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                schema: "SS",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "SS",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Producten",
                schema: "SS",
                newName: "Product",
                newSchema: "SS");

            migrationBuilder.RenameTable(
                name: "Inschrijvingen",
                schema: "SS",
                newName: "Inschrijving",
                newSchema: "SS");

            migrationBuilder.RenameTable(
                name: "EvenementTypes",
                schema: "SS",
                newName: "EvenementType",
                newSchema: "SS");

            migrationBuilder.RenameTable(
                name: "Evenementen",
                schema: "SS",
                newName: "Evenement",
                newSchema: "SS");

            migrationBuilder.RenameTable(
                name: "DrankkaartTypes",
                schema: "SS",
                newName: "DrankkaartType",
                newSchema: "SS");

            migrationBuilder.RenameTable(
                name: "Drankkaarten",
                schema: "SS",
                newName: "Drankkaart",
                newSchema: "SS");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "SS",
                newName: "Categorie",
                newSchema: "SS");

            migrationBuilder.RenameTable(
                name: "Bestellingen",
                schema: "SS",
                newName: "Bestelling",
                newSchema: "SS");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "SS",
                newName: "User",
                newSchema: "SS");

            migrationBuilder.RenameIndex(
                name: "IX_Producten_CategorieID",
                schema: "SS",
                table: "Product",
                newName: "IX_Product_CategorieID");

            migrationBuilder.RenameIndex(
                name: "IX_Inschrijvingen_UserId",
                schema: "SS",
                table: "Inschrijving",
                newName: "IX_Inschrijving_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Inschrijvingen_EvenementID",
                schema: "SS",
                table: "Inschrijving",
                newName: "IX_Inschrijving_EvenementID");

            migrationBuilder.RenameIndex(
                name: "IX_Evenementen_EvenementTypeID",
                schema: "SS",
                table: "Evenement",
                newName: "IX_Evenement_EvenementTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Drankkaarten_UserId",
                schema: "SS",
                table: "Drankkaart",
                newName: "IX_Drankkaart_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Drankkaarten_DrankkaartTypeID",
                schema: "SS",
                table: "Drankkaart",
                newName: "IX_Drankkaart_DrankkaartTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Bestellingen_UserId",
                schema: "SS",
                table: "Bestelling",
                newName: "IX_Bestelling_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "token",
                schema: "SS",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Voornaam",
                schema: "SS",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Achternaam",
                schema: "SS",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Pincode",
                schema: "SS",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                schema: "SS",
                table: "Product",
                column: "ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inschrijving",
                schema: "SS",
                table: "Inschrijving",
                column: "InschrijvingID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EvenementType",
                schema: "SS",
                table: "EvenementType",
                column: "EvenementTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Evenement",
                schema: "SS",
                table: "Evenement",
                column: "EvenementID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DrankkaartType",
                schema: "SS",
                table: "DrankkaartType",
                column: "DrankkaartTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drankkaart",
                schema: "SS",
                table: "Drankkaart",
                column: "DrankkaartID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorie",
                schema: "SS",
                table: "Categorie",
                column: "CategorieID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bestelling",
                schema: "SS",
                table: "Bestelling",
                column: "BestellingID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "SS",
                table: "User",
                column: "Id");

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
                name: "FK_Drankkaart_DrankkaartType_DrankkaartTypeID",
                schema: "SS",
                table: "Drankkaart",
                column: "DrankkaartTypeID",
                principalSchema: "SS",
                principalTable: "DrankkaartType",
                principalColumn: "DrankkaartTypeID",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Evenement_EvenementType_EvenementTypeID",
                schema: "SS",
                table: "Evenement",
                column: "EvenementTypeID",
                principalSchema: "SS",
                principalTable: "EvenementType",
                principalColumn: "EvenementTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijving_Evenement_EvenementID",
                schema: "SS",
                table: "Inschrijving",
                column: "EvenementID",
                principalSchema: "SS",
                principalTable: "Evenement",
                principalColumn: "EvenementID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inschrijving_User_UserId",
                schema: "SS",
                table: "Inschrijving",
                column: "UserId",
                principalSchema: "SS",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categorie_CategorieID",
                schema: "SS",
                table: "Product",
                column: "CategorieID",
                principalSchema: "SS",
                principalTable: "Categorie",
                principalColumn: "CategorieID",
                onDelete: ReferentialAction.Cascade);

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
    }
}
