using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myhealthhub.api.Migrations
{
    public partial class AddingTrialFormAndRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrialForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormLabelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhysicianId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTrial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SiteId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodPressure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodyWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EPGUsed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EPGModelNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EPGSerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalNumberLeads = table.Column<int>(type: "int", nullable: false),
                    APImagesCollectionStatus = table.Column<bool>(type: "bit", nullable: false),
                    LateralImagesCollectionStatus = table.Column<bool>(type: "bit", nullable: false),
                    ImagesEncryptedMemoryDriveStatus = table.Column<bool>(type: "bit", nullable: false),
                    ManufacturerLead1Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturerLead1Lot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturerLead1Serial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturerLead1Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinalLevelLead1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturerLead2Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturerLead2Lot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturerLead2Serial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturerLead2Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinalLevelLead2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnatomicalGuidanceLeadStatus = table.Column<bool>(type: "bit", nullable: false),
                    ParesthesiaMappingStatus = table.Column<bool>(type: "bit", nullable: true),
                    XMLFileDonwloadAndProvidedStatus = table.Column<bool>(type: "bit", nullable: false),
                    ProgramNumber1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaveForm1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinalLevelFirstAnode1Lead1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinalLevelFirstAnode1Lead2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinalLevelFirstCathode1Lead1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinalLevelFirstCathode1Lead2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramNumber2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaveForm2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinalLevelFirstAnode2Lead1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinalLevelFirstAnode2Lead2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinalLevelFirstCathode2Lead1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinalLevelFirstCathode2Lead2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramNumber3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaveForm3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinalLevelFirstAnode3Lead1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinalLevelFirstAnode3Lead2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinalLevelFirstCathode3Lead1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinalLevelFirstCathode3Lead2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramNumber4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaveForm4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinalLevelFirstAnode4Lead1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinalLevelFirstAnode4Lead2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinalLevelFirstCathode4Lead1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinalLevelFirstCathode4Lead2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramNumber5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaveForm5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinalLevelFirstAnode5Lead1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinalLevelFirstAnode5Lead2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinalLevelFirstCathode5Lead1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinalLevelFirstCathode5Lead2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationProcedure = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrialForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrialForms_FormsLabels_FormLabelId",
                        column: x => x.FormLabelId,
                        principalTable: "FormsLabels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrialForms_Physicians_PhysicianId",
                        column: x => x.PhysicianId,
                        principalTable: "Physicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrialForms_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrialForms_FormLabelId",
                table: "TrialForms",
                column: "FormLabelId");

            migrationBuilder.CreateIndex(
                name: "IX_TrialForms_PhysicianId",
                table: "TrialForms",
                column: "PhysicianId");

            migrationBuilder.CreateIndex(
                name: "IX_TrialForms_VisitId",
                table: "TrialForms",
                column: "VisitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrialForms");
        }
    }
}
