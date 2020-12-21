using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Data.Migrations
{
    public partial class Correction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantDetails_GrantProgram_GrantId",
                table: "ApplicantDetails");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantDetails_GrantId",
                table: "ApplicantDetails");

            migrationBuilder.DropColumn(
                name: "GrantId",
                table: "ApplicantDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GrantId",
                table: "ApplicantDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantDetails_GrantId",
                table: "ApplicantDetails",
                column: "GrantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantDetails_GrantProgram_GrantId",
                table: "ApplicantDetails",
                column: "GrantId",
                principalTable: "GrantProgram",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
