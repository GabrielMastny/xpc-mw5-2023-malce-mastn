using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eshop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenamingOfProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RelatedTo",
                table: "Review",
                newName: "RelatedToId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_RelatedToId",
                table: "Review",
                column: "RelatedToId");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_CategoryId",
                table: "Commodity",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_ManufacturerId",
                table: "Commodity",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodity_Category_CategoryId",
                table: "Commodity",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commodity_Manufacturer_ManufacturerId",
                table: "Commodity",
                column: "ManufacturerId",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Commodity_RelatedToId",
                table: "Review",
                column: "RelatedToId",
                principalTable: "Commodity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commodity_Category_CategoryId",
                table: "Commodity");

            migrationBuilder.DropForeignKey(
                name: "FK_Commodity_Manufacturer_ManufacturerId",
                table: "Commodity");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Commodity_RelatedToId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_RelatedToId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Commodity_CategoryId",
                table: "Commodity");

            migrationBuilder.DropIndex(
                name: "IX_Commodity_ManufacturerId",
                table: "Commodity");

            migrationBuilder.RenameColumn(
                name: "RelatedToId",
                table: "Review",
                newName: "RelatedTo");
        }
    }
}
