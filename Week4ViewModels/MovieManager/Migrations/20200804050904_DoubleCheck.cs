using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieManager.Migrations
{
    public partial class DoubleCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "catagory",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "catagoryID",
                table: "Movies",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "catagoryID",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "catagory",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
