using Microsoft.EntityFrameworkCore.Migrations;

namespace SIRH.Migrations
{
    public partial class Spontane : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidatureSpont",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobInterviewDate = table.Column<string>(maxLength: 10, nullable: true),
                    CandidatureDate = table.Column<string>(maxLength: 10, nullable: false),
                    CoverLetterPath = table.Column<string>(maxLength: 255, nullable: false),
                    CandidateId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatureSpont", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatureSpont_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatureSpont_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatureSpont_CandidateId",
                table: "CandidatureSpont",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatureSpont_StatusId",
                table: "CandidatureSpont",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatureSpont");
        }
    }
}
