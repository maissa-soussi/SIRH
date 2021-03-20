using Microsoft.EntityFrameworkCore.Migrations;

namespace SIRH.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(maxLength: 50, nullable: false),
                    Street = table.Column<string>(maxLength: 100, nullable: false),
                    ZipCode = table.Column<int>(nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    PicturePath = table.Column<string>(maxLength: 255, nullable: true),
                    Phone = table.Column<string>(maxLength: 8, nullable: false),
                    BirthdayDate = table.Column<string>(maxLength: 10, nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidate_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateExperience",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(maxLength: 50, nullable: false),
                    Profession = table.Column<string>(maxLength: 50, nullable: false),
                    StartDate = table.Column<string>(maxLength: 10, nullable: false),
                    EndDate = table.Column<string>(maxLength: 10, nullable: false),
                    ExperienceId = table.Column<int>(nullable: false),
                    DomainId = table.Column<int>(nullable: false),
                    CandidateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateExperience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateExperience_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateExperience_Domain_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateExperience_Experience_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experience",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_UserId",
                table: "Candidate",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExperience_CandidateId",
                table: "CandidateExperience",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExperience_DomainId",
                table: "CandidateExperience",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExperience_ExperienceId",
                table: "CandidateExperience",
                column: "ExperienceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateExperience");

            migrationBuilder.DropTable(
                name: "Candidate");
        }
    }
}
