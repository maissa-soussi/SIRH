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
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
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
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    Role = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidateDiploma",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(maxLength: 10, nullable: false),
                    University = table.Column<string>(maxLength: 50, nullable: false),
                    DomainId = table.Column<int>(nullable: false),
                    DiplomaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateDiploma", x => x.Id);
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
                    CurrencyId = table.Column<int>(nullable: false),
                    MinSalary = table.Column<int>(nullable: false),
                    MaxSalary = table.Column<int>(nullable: false),
                    PublicationDate = table.Column<string>(maxLength: 10, nullable: false),
                    ExpirationDate = table.Column<string>(maxLength: 10, nullable: false)
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
                        name: "FK_JobOffer_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOffer_Diploma_DiplomaId",
                        column: x => x.DiplomaId,
                        principalTable: "Diploma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobOffer_Experience_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experience",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateDiploma_DiplomaId",
                table: "CandidateDiploma",
                column: "DiplomaId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateDiploma_DomainId",
                table: "CandidateDiploma",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_ContratTypeId",
                table: "JobOffer",
                column: "ContratTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_CountryId",
                table: "JobOffer",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_CurrencyId",
                table: "JobOffer",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_DiplomaId",
                table: "JobOffer",
                column: "DiplomaId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_ExperienceId",
                table: "JobOffer",
                column: "ExperienceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateDiploma");

            migrationBuilder.DropTable(
                name: "JobOffer");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Domain");

            migrationBuilder.DropTable(
                name: "ContratType");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Diploma");

            migrationBuilder.DropTable(
                name: "Experience");
        }
    }
}
