using Microsoft.EntityFrameworkCore.Migrations;

namespace SIRH.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "CandidateDiploma",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateDiploma_CandidateId",
                table: "CandidateDiploma",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateDiploma_Candidate_CandidateId",
                table: "CandidateDiploma",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateDiploma_Candidate_CandidateId",
                table: "CandidateDiploma");

            migrationBuilder.DropIndex(
                name: "IX_CandidateDiploma_CandidateId",
                table: "CandidateDiploma");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "CandidateDiploma");
        }
    }
}
