using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class NullableStateId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantDetails_States_StateId",
                table: "ApplicantDetails");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "ApplicantDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantDetails_States_StateId",
                table: "ApplicantDetails",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantDetails_States_StateId",
                table: "ApplicantDetails");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "ApplicantDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantDetails_States_StateId",
                table: "ApplicantDetails",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
