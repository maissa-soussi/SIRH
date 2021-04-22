using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIRH.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContratType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diploma",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diploma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Domain",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrivingLicence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrivingLicence", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LanguageLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryWish",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salary = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryWish", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    Role = table.Column<string>(maxLength: 100, nullable: true),
                    RefreshToken = table.Column<string>(nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobOffer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    DiplomaId = table.Column<int>(nullable: true),
                    ExperienceId = table.Column<int>(nullable: true),
                    ContratTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MinSalary = table.Column<int>(nullable: false),
                    MaxSalary = table.Column<int>(nullable: false),
                    PublicationDate = table.Column<string>(maxLength: 10, nullable: false),
                    ExpirationDate = table.Column<string>(maxLength: 10, nullable: false),
                    DomainId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOffer_ContratType_ContratTypeId",
                        column: x => x.ContratTypeId,
                        principalTable: "ContratType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOffer_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOffer_Diploma_DiplomaId",
                        column: x => x.DiplomaId,
                        principalTable: "Diploma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobOffer_Domain_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOffer_Experience_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experience",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Other",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacebookUrl = table.Column<string>(nullable: true),
                    LinkedinUrl = table.Column<string>(nullable: true),
                    SalaryWishId = table.Column<int>(nullable: false),
                    DrivingLicenceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Other", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Other_DrivingLicence_DrivingLicenceId",
                        column: x => x.DrivingLicenceId,
                        principalTable: "DrivingLicence",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Other_SalaryWish_SalaryWishId",
                        column: x => x.SalaryWishId,
                        principalTable: "SalaryWish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    CvPath = table.Column<string>(maxLength: 255, nullable: false),
                    Phone = table.Column<string>(maxLength: 8, nullable: false),
                    BirthdayDate = table.Column<string>(maxLength: 10, nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    OtherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidate_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidate_Other_OtherId",
                        column: x => x.OtherId,
                        principalTable: "Other",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidate_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateDiploma",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(maxLength: 10, nullable: false),
                    University = table.Column<string>(maxLength: 50, nullable: false),
                    CandidateId = table.Column<int>(nullable: false),
                    DomainId = table.Column<int>(nullable: false),
                    DiplomaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateDiploma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateDiploma_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateDiploma_Diploma_DiplomaId",
                        column: x => x.DiplomaId,
                        principalTable: "Diploma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateDiploma_Domain_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domain",
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

            migrationBuilder.CreateTable(
                name: "Candidature",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobInterviewDate = table.Column<string>(maxLength: 10, nullable: true),
                    CandidatureDate = table.Column<string>(maxLength: 10, nullable: false),
                    CoverLetterPath = table.Column<string>(maxLength: 255, nullable: false),
                    JobOfferId = table.Column<int>(nullable: true),
                    CandidateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidature_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidature_JobOffer_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Candidate_UserId",
                table: "Candidate",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateDiploma_CandidateId",
                table: "CandidateDiploma",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateDiploma_DiplomaId",
                table: "CandidateDiploma",
                column: "DiplomaId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateDiploma_DomainId",
                table: "CandidateDiploma",
                column: "DomainId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Candidature_CandidateId",
                table: "Candidature",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidature_JobOfferId",
                table: "Candidature",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_ContratTypeId",
                table: "JobOffer",
                column: "ContratTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_CountryId",
                table: "JobOffer",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_DiplomaId",
                table: "JobOffer",
                column: "DiplomaId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_DomainId",
                table: "JobOffer",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_ExperienceId",
                table: "JobOffer",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Other_DrivingLicenceId",
                table: "Other",
                column: "DrivingLicenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Other_SalaryWishId",
                table: "Other",
                column: "SalaryWishId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateDiploma");

            migrationBuilder.DropTable(
                name: "CandidateExperience");

            migrationBuilder.DropTable(
                name: "CandidateLanguage");

            migrationBuilder.DropTable(
                name: "Candidature");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "LanguageLevel");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "JobOffer");

            migrationBuilder.DropTable(
                name: "Other");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ContratType");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Diploma");

            migrationBuilder.DropTable(
                name: "Domain");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "DrivingLicence");

            migrationBuilder.DropTable(
                name: "SalaryWish");
        }
    }
}
