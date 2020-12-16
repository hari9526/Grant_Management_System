using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Data.Migrations
{
    public partial class RemainingTablesCreatedUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantDetail_UserInfo_Id",
                table: "ApplicantDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGrantMapping_GrantProgram_GrantId",
                table: "UserGrantMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGrantMapping_UserInfo_UserId",
                table: "UserGrantMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGrantMapping",
                table: "UserGrantMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantDetail",
                table: "ApplicantDetail");

            migrationBuilder.RenameTable(
                name: "UserGrantMapping",
                newName: "UserGrantMappings");

            migrationBuilder.RenameTable(
                name: "ApplicantDetail",
                newName: "ApplicantDetails");

            migrationBuilder.RenameIndex(
                name: "IX_UserGrantMapping_UserId",
                table: "UserGrantMappings",
                newName: "IX_UserGrantMappings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGrantMapping_GrantId",
                table: "UserGrantMappings",
                newName: "IX_UserGrantMappings_GrantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGrantMappings",
                table: "UserGrantMappings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantDetails",
                table: "ApplicantDetails",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EducationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    InstitutionName = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    YearOfCompletion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantDetails_EducationalDetailId",
                table: "ApplicantDetails",
                column: "EducationalDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantDetails_EducationDetails_EducationalDetailId",
                table: "ApplicantDetails",
                column: "EducationalDetailId",
                principalTable: "EducationDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantDetails_UserInfo_Id",
                table: "ApplicantDetails",
                column: "Id",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGrantMappings_GrantProgram_GrantId",
                table: "UserGrantMappings",
                column: "GrantId",
                principalTable: "GrantProgram",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGrantMappings_UserInfo_UserId",
                table: "UserGrantMappings",
                column: "UserId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantDetails_EducationDetails_EducationalDetailId",
                table: "ApplicantDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantDetails_UserInfo_Id",
                table: "ApplicantDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGrantMappings_GrantProgram_GrantId",
                table: "UserGrantMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGrantMappings_UserInfo_UserId",
                table: "UserGrantMappings");

            migrationBuilder.DropTable(
                name: "EducationDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGrantMappings",
                table: "UserGrantMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantDetails",
                table: "ApplicantDetails");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantDetails_EducationalDetailId",
                table: "ApplicantDetails");

            migrationBuilder.RenameTable(
                name: "UserGrantMappings",
                newName: "UserGrantMapping");

            migrationBuilder.RenameTable(
                name: "ApplicantDetails",
                newName: "ApplicantDetail");

            migrationBuilder.RenameIndex(
                name: "IX_UserGrantMappings_UserId",
                table: "UserGrantMapping",
                newName: "IX_UserGrantMapping_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGrantMappings_GrantId",
                table: "UserGrantMapping",
                newName: "IX_UserGrantMapping_GrantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGrantMapping",
                table: "UserGrantMapping",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantDetail",
                table: "ApplicantDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantDetail_UserInfo_Id",
                table: "ApplicantDetail",
                column: "Id",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGrantMapping_GrantProgram_GrantId",
                table: "UserGrantMapping",
                column: "GrantId",
                principalTable: "GrantProgram",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGrantMapping_UserInfo_UserId",
                table: "UserGrantMapping",
                column: "UserId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
