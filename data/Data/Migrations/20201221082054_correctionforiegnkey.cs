using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Data.Migrations
{
    public partial class correctionforiegnkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantDetails_GrantProgram_GrantId",
                table: "ApplicantDetails");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantDetails_GrantId",
                table: "ApplicantDetails");
        }
    }
}
