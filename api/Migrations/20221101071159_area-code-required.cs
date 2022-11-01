using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class areacoderequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Area_Code",
                table: "Area");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Area",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Area_Code",
                table: "Area",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Area_Code",
                table: "Area");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Area",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Area_Code",
                table: "Area",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }
    }
}
