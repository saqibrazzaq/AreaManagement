using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class areacodeuniqueremove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Area_Code_CityId",
                table: "Area");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Area_Code_CityId",
                table: "Area",
                columns: new[] { "Code", "CityId" },
                unique: true);
        }
    }
}
