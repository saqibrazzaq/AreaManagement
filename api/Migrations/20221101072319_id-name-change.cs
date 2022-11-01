using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class idnamechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Area_City_CityCode",
                table: "Area");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "State",
                newName: "StateId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Country",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "City",
                newName: "CityId");

            migrationBuilder.RenameColumn(
                name: "CityCode",
                table: "Area",
                newName: "CityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Area",
                newName: "AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_Area_CityCode",
                table: "Area",
                newName: "IX_Area_CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Area_City_CityId",
                table: "Area",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Area_City_CityId",
                table: "Area");

            migrationBuilder.RenameColumn(
                name: "StateId",
                table: "State",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Country",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "City",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Area",
                newName: "CityCode");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "Area",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Area_CityId",
                table: "Area",
                newName: "IX_Area_CityCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Area_City_CityCode",
                table: "Area",
                column: "CityCode",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
