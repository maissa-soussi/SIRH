using Microsoft.EntityFrameworkCore.Migrations;

namespace SIRH.Migrations
{
    public partial class OtherMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Other");
        }
    }
}
