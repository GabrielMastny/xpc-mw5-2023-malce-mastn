#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDb.Migrations
{
    /// <inheritdoc />
    public partial class adjustements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commodity_Category_CategoryID",
                table: "Commodity");

            migrationBuilder.DropForeignKey(
                name: "FK_Commodity_Manufacturer_ManufacturerID",
                table: "Commodity");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Commodity_CommodityID",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_CommodityID",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Commodity_CategoryID",
                table: "Commodity");

            migrationBuilder.DropIndex(
                name: "IX_Commodity_ManufacturerID",
                table: "Commodity");

            migrationBuilder.DropColumn(
                name: "CommodityID",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Review",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Manufacturer",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ManufacturerID",
                table: "Commodity",
                newName: "ManufacturerId");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Commodity",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Commodity",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Commodity",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Category",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Review",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Stars",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Review",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CountryOfOrigin",
                table: "Manufacturer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Manufacturer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Manufacturer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "Stars",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "CountryOfOrigin",
                table: "Manufacturer");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Manufacturer");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Manufacturer");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Review",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Manufacturer",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ManufacturerId",
                table: "Commodity",
                newName: "ManufacturerID");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Commodity",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Commodity",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Commodity",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Category",
                newName: "ID");

            migrationBuilder.AddColumn<Guid>(
                name: "CommodityID",
                table: "Review",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_CommodityID",
                table: "Review",
                column: "CommodityID");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_CategoryID",
                table: "Commodity",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_ManufacturerID",
                table: "Commodity",
                column: "ManufacturerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodity_Category_CategoryID",
                table: "Commodity",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commodity_Manufacturer_ManufacturerID",
                table: "Commodity",
                column: "ManufacturerID",
                principalTable: "Manufacturer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Commodity_CommodityID",
                table: "Review",
                column: "CommodityID",
                principalTable: "Commodity",
                principalColumn: "ID");
        }
    }
}
