using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangoMartDb.Migrations
{
    /// <inheritdoc />
    public partial class ChangedNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_ProductImage_ProductImageId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ProductImageId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ProductImageId",
                table: "Images");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductImageId",
                table: "Images",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductImageId",
                table: "Images",
                column: "ProductImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_ProductImage_ProductImageId",
                table: "Images",
                column: "ProductImageId",
                principalTable: "ProductImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
