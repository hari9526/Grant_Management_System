using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class CountryTableCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortName",
                table: "Countries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SortName",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
