using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Data.Migrations
{
    public partial class RemainingTablesCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicantDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    GrantId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    EducationalDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantDetail_UserInfo_Id",
                        column: x => x.Id,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGrantMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GrantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGrantMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGrantMapping_GrantProgram_GrantId",
                        column: x => x.GrantId,
                        principalTable: "GrantProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGrantMapping_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserGrantMapping_GrantId",
                table: "UserGrantMapping",
                column: "GrantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGrantMapping_UserId",
                table: "UserGrantMapping",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantDetail");

            migrationBuilder.DropTable(
                name: "UserGrantMapping");
        }
    }
}
