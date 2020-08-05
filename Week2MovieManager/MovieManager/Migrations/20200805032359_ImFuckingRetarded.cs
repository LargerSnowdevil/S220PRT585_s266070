using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieManager.Migrations
{
    public partial class ImFuckingRetarded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_catagoryID",
                table: "Movies",
                column: "catagoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Catagorys_catagoryID",
                table: "Movies",
                column: "catagoryID",
                principalTable: "Catagorys",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Catagorys_catagoryID",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_catagoryID",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "catagoryID",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "catagoryIDid",
                table: "Movies",
                type: "int",
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
    }
}
