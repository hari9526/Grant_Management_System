using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Data.Migrations
{
    public partial class ReviewAndApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationStatus",
                table: "UserGrantMappings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ReviewerStatus",
                table: "UserGrantMappings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationStatus",
                table: "UserGrantMappings");

            migrationBuilder.DropColumn(
                name: "ReviewerStatus",
                table: "UserGrantMappings");
        }
    }
}
