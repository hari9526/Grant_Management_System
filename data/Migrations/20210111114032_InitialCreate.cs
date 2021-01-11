using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    PhoneCode = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrantProgram",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ProgramCode = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrantProgram", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    Country_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_Country_Id",
                        column: x => x.Country_Id,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    InstitutionName = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    YearOfCompletion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationDetails_UserInfo_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGrantMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GrantId = table.Column<int>(type: "int", nullable: false),
                    ReviewerStatus = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGrantMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGrantMappings_GrantProgram_GrantId",
                        column: x => x.GrantId,
                        principalTable: "GrantProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGrantMappings_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantDetails_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantDetails_UserInfo_Id",
                        column: x => x.Id,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantDetails_StateId",
                table: "ApplicantDetails",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationDetails_ApplicantId",
                table: "EducationDetails",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_States_Country_Id",
                table: "States",
                column: "Country_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserGrantMappings_GrantId",
                table: "UserGrantMappings",
                column: "GrantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGrantMappings_UserId",
                table: "UserGrantMappings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantDetails");

            migrationBuilder.DropTable(
                name: "EducationDetails");

            migrationBuilder.DropTable(
                name: "UserGrantMappings");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "GrantProgram");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
