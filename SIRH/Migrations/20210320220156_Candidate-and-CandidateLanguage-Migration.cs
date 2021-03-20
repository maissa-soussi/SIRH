using Microsoft.EntityFrameworkCore.Migrations;

namespace SIRH.Migrations
{
    public partial class CandidateandCandidateLanguageMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Candidate",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CvPath",
                table: "Candidate",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OtherId",
                table: "Candidate",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CandidateLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    LanguageLevelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateLanguage_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateLanguage_LanguageLevel_LanguageLevelId",
                        column: x => x.LanguageLevelId,
                        principalTable: "LanguageLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_CountryId",
                table: "Candidate",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_OtherId",
                table: "Candidate",
                column: "OtherId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateLanguage_CandidateId",
                table: "CandidateLanguage",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateLanguage_LanguageId",
                table: "CandidateLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateLanguage_LanguageLevelId",
                table: "CandidateLanguage",
                column: "LanguageLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Country_CountryId",
                table: "Candidate",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Other_OtherId",
                table: "Candidate",
                column: "OtherId",
                principalTable: "Other",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Country_CountryId",
                table: "Candidate");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Other_OtherId",
                table: "Candidate");

            migrationBuilder.DropTable(
                name: "CandidateLanguage");

            migrationBuilder.DropIndex(
                name: "IX_Candidate_CountryId",
                table: "Candidate");

            migrationBuilder.DropIndex(
                name: "IX_Candidate_OtherId",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "CvPath",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "OtherId",
                table: "Candidate");
        }
    }
}
