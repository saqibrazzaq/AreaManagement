using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class uniquenamecode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Area",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                name: "IX_Country_Code",
                table: "Country",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_Name",
                table: "Country",
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
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Area_Name",
                table: "Area",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_State_Code",
                table: "State");

            migrationBuilder.DropIndex(
                name: "IX_State_Name",
                table: "State");

            migrationBuilder.DropIndex(
                name: "IX_Country_Code",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Country_Name",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "IX_City_Name",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_Area_Code",
                table: "Area");

            migrationBuilder.DropIndex(
                name: "IX_Area_Name",
                table: "Area");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Area",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
