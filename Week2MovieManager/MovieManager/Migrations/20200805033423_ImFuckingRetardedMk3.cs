using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieManager.Migrations
{
    public partial class ImFuckingRetardedMk3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Catagorys_catagoryID",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catagorys",
                table: "Catagorys");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Catagorys");

            migrationBuilder.AddColumn<int>(
                name: "movieID",
                table: "Movies",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "catagoryID",
                table: "Catagorys",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "movieID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catagorys",
                table: "Catagorys",
                column: "catagoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Catagorys_catagoryID",
                table: "Movies",
                column: "catagoryID",
                principalTable: "Catagorys",
                principalColumn: "catagoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Catagorys_catagoryID",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catagorys",
                table: "Catagorys");

            migrationBuilder.DropColumn(
                name: "movieID",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "catagoryID",
                table: "Catagorys");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Catagorys",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catagorys",
                table: "Catagorys",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Catagorys_catagoryID",
                table: "Movies",
                column: "catagoryID",
                principalTable: "Catagorys",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
