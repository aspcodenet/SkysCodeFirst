using Microsoft.EntityFrameworkCore.Migrations;

namespace SkysCodeFirst.Migrations
{
    public partial class Addedcounty2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountyId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_CountyId",
                table: "Person",
                column: "CountyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_County_CountyId",
                table: "Person",
                column: "CountyId",
                principalTable: "County",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_County_CountyId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_CountyId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "CountyId",
                table: "Person");
        }
    }
}
