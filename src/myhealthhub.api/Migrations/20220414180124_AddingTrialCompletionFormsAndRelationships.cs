using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myhealthhub.api.Migrations
{
    public partial class AddingTrialCompletionFormsAndRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrialCompletionForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormLabelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhysicianId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTrialImplant = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SiteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PainLocationNatureStatus = table.Column<bool>(type: "bit", nullable: false),
                    StudyTreatmentFeedbackStatus = table.Column<bool>(type: "bit", nullable: false),
                    VideoMotorAssessmentStatus = table.Column<bool>(type: "bit", nullable: false),
                    BloodPressure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodyWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    APIImagesCollectionStatus = table.Column<bool>(type: "bit", nullable: false),
                    LateralImagesCollectionStatus = table.Column<bool>(type: "bit", nullable: false),
                    SpinalLevelCoverageLead1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpinalLevelCoverageLead2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageAddedEncryptedDriveStatus = table.Column<bool>(type: "bit", nullable: false),
                    DateTimeRemovalNeuromodulation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdjustmentsMadeTrialPeriodStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrialCompletionForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrialCompletionForms_FormsLabels_FormLabelId",
                        column: x => x.FormLabelId,
                        principalTable: "FormsLabels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrialCompletionForms_Physicians_PhysicianId",
                        column: x => x.PhysicianId,
                        principalTable: "Physicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrialCompletionForms_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrialCompletionForms_FormLabelId",
                table: "TrialCompletionForms",
                column: "FormLabelId");

            migrationBuilder.CreateIndex(
                name: "IX_TrialCompletionForms_PhysicianId",
                table: "TrialCompletionForms",
                column: "PhysicianId");

            migrationBuilder.CreateIndex(
                name: "IX_TrialCompletionForms_VisitId",
                table: "TrialCompletionForms",
                column: "VisitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrialCompletionForms");
        }
    }
}
