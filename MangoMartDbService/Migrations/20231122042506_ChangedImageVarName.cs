using Microsoft.EntityFrameworkCore.Migrations;

namespace MangoMartDbService.Migrations
{
    public partial class ChangedImageVarName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageFilePath",
                table: "Products",
                newName: "Image");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Products",
                newName: "ImageFilePath");
        }
    }
}
