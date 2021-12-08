using Microsoft.EntityFrameworkCore.Migrations;

namespace SkysCodeFirst.Migrations
{
    public partial class Addedshowsize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoeSize",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShoeSize",
                table: "Person");
        }
    }
}
