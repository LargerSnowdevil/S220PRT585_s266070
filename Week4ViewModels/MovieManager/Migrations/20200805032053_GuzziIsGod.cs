using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieManager.Migrations
{
    public partial class GuzziIsGod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "catagoryID",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "catagoryIDid",
                table: "Movies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_catagoryIDid",
                table: "Movies",
                column: "catagoryIDid");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Catagorys_catagoryIDid",
                table: "Movies",
                column: "catagoryIDid",
                principalTable: "Catagorys",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Catagorys_catagoryIDid",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_catagoryIDid",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "catagoryIDid",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "catagoryID",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
