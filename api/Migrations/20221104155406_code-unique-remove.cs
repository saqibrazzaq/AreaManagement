using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class codeuniqueremove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_State_Name_CountryId",
                table: "State");

            migrationBuilder.DropIndex(
                name: "IX_Area_Name_CityId",
                table: "Area");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_State_Name_CountryId",
                table: "State",
                columns: new[] { "Name", "CountryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Area_Name_CityId",
                table: "Area",
                columns: new[] { "Name", "CityId" },
                unique: true);
        }
    }
}
