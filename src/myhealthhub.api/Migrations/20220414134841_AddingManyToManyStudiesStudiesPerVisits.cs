using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myhealthhub.api.Migrations
{
    public partial class AddingManyToManyStudiesStudiesPerVisits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Studies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudiesPerVisits",
                columns: table => new
                {
                    VisitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudiesPerVisits", x => new { x.StudyId, x.VisitId });
                    table.ForeignKey(
                        name: "FK_StudiesPerVisits_Studies_StudyId",
                        column: x => x.StudyId,
                        principalTable: "Studies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudiesPerVisits_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudiesPerVisits_VisitId",
                table: "StudiesPerVisits",
                column: "VisitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudiesPerVisits");

            migrationBuilder.DropTable(
                name: "Studies");
        }
    }
}
