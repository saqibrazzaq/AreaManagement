using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class indexuniquecode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_State_Code",
                table: "State");

            migrationBuilder.DropIndex(
                name: "IX_State_Name",
                table: "State");

            migrationBuilder.DropIndex(
                name: "IX_City_Name",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_Area_Code",
                table: "Area");

            migrationBuilder.DropIndex(
                name: "IX_Area_Name",
                table: "Area");

            migrationBuilder.CreateIndex(
                name: "IX_State_Code_CountryId",
                table: "State",
                columns: new[] { "Code", "CountryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_State_Name_CountryId",
                table: "State",
                columns: new[] { "Name", "CountryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_City_Name_StateId",
                table: "City",
                columns: new[] { "Name", "StateId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Area_Code_CityId",
                table: "Area",
                columns: new[] { "Code", "CityId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Area_Name_CityId",
                table: "Area",
                columns: new[] { "Name", "CityId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_State_Code_CountryId",
                table: "State");

            migrationBuilder.DropIndex(
                name: "IX_State_Name_CountryId",
                table: "State");

            migrationBuilder.DropIndex(
                name: "IX_City_Name_StateId",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_Area_Code_CityId",
                table: "Area");

            migrationBuilder.DropIndex(
                name: "IX_Area_Name_CityId",
                table: "Area");

            migrationBuilder.CreateIndex(
                name: "IX_State_Code",
                table: "State",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_State_Name",
                table: "State",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_City_Name",
                table: "City",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Area_Code",
                table: "Area",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Area_Name",
                table: "Area",
                column: "Name",
                unique: true);
        }
    }
}
