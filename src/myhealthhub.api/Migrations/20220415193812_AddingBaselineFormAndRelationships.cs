using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myhealthhub.api.Migrations
{
    public partial class AddingBaselineFormAndRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaselineForm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormLabelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhysicianId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTimeBaseline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SiteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgeConsent = table.Column<int>(type: "int", nullable: false),
                    Ethinicity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RaceAmericanIndian = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaceAsian = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaceBlackAfrican = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaceNativeHawaian = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaceWhiteCaucasian = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaceOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaceDeclined = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodPressure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkSituation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PainPreventToWork = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaysMissedDuePain = table.Column<int>(type: "int", nullable: false),
                    ImpactPainInLife = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExerciseFrequence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceSituation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkCompensation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActiveLitigation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmokerStatus = table.Column<bool>(type: "bit", nullable: false),
                    TimeChronicPainYears = table.Column<int>(type: "int", nullable: true),
                    TimeChronicPainMonths = table.Column<int>(type: "int", nullable: true),
                    ChronicPainRecurrency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChronicPainEpisodeLasting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChronicPainEpisodeIntensity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChronicPainEpisodeFrequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChronicPainEpisodeFrequencyComparisson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LevelPainZeroToTen = table.Column<int>(type: "int", nullable: false),
                    ChronicPainLocationFrontStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChronicPainLocationFront1 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront2 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront3 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront4 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront5 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront6 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront7 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront8 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront9 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront10 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront11 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront12 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront13 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront14 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront15 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront16 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront17 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront18 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront19 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront20 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront21 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront22 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront23 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront24 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationBackStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChronicPainLocationFront25 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront26 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront27 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront28 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront29 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront30 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront31 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront32 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront33 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront34 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront35 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront36 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront37 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront38 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront39 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront40 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront41 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront42 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront43 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPainLocationFront44 = table.Column<bool>(type: "bit", nullable: false),
                    ChronicPostOperativePainStatus = table.Column<bool>(type: "bit", nullable: false),
                    PostOperativePainTypeSurgery1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostOperativePainTypeSurgery2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostOperativePainTypeSurgery3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostOperativePainTypeSurgery4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostOperativePainTypeSurgery5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostOperativePainTypeSurgeryYear1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostOperativePainTypeSurgeryYear2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostOperativePainTypeSurgeryYear3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostOperativePainTypeSurgeryYear4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostOperativePainTypeSurgeryYear5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FalledBackSurgerySyndromeStatus = table.Column<bool>(type: "bit", nullable: false),
                    FalledBackSyndromeTypeSurgery1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FalledBackSyndromeTypeSurgery2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FalledBackSyndromeTypeSurgery3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FalledBackSyndromeTypeSurgery4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FalledBackSyndromeTypeSurgery5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FalledBackSyndromeTypeSurgeryLevel1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FalledBackSyndromeTypeSurgeryLevel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FalledBackSyndromeTypeSurgeryLevel3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FalledBackSyndromeTypeSurgeryLevel4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FalledBackSyndromeTypeSurgeryLevel5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackPainStatus = table.Column<bool>(type: "bit", nullable: false),
                    BackPainFBSSStatus = table.Column<bool>(type: "bit", nullable: false),
                    NeckUperLimbSchemiaStatus = table.Column<bool>(type: "bit", nullable: false),
                    CriticalLimbSchemiaStatus = table.Column<bool>(type: "bit", nullable: false),
                    VisceralPainStatus = table.Column<bool>(type: "bit", nullable: false),
                    AnginaStatus = table.Column<bool>(type: "bit", nullable: false),
                    PeripheralNeuropathyStatus = table.Column<bool>(type: "bit", nullable: false),
                    DiabeticStatus = table.Column<bool>(type: "bit", nullable: false),
                    ChemotherapyRelatedStatus = table.Column<bool>(type: "bit", nullable: false),
                    ReflexSympatheticDystrophyStatus = table.Column<bool>(type: "bit", nullable: false),
                    CausalgiaStatus = table.Column<bool>(type: "bit", nullable: false),
                    CausalgiaMuscle = table.Column<bool>(type: "bit", nullable: false),
                    PostAmputationStatus = table.Column<bool>(type: "bit", nullable: false),
                    SubjectPrimaryChronicPainIndication = table.Column<bool>(type: "bit", nullable: false),
                    TreatmentForPainStatus = table.Column<bool>(type: "bit", nullable: false),
                    TreatmentYesOccupationalTherapy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatmentYesAcunpunture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatmentYesPhysicalTherapy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatmentYesMassageTherapy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatmentYesChiropracticTherapy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatmentYesCogBehavioralTherapy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatmentYesPsychotherapy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatmentYesHypnotherapy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InjectionsInterventionsStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IITransforraminal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IITranslaminar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IICaudal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IIFacetInjections = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IISacroillacJoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IIOtherJoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IIRadiofrequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IIIntradiscal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IIPreviousSCS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IIPreviousDRG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImplantableDrug = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaselineForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaselineForm_FormsLabels_FormLabelId",
                        column: x => x.FormLabelId,
                        principalTable: "FormsLabels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaselineForm_Physicians_PhysicianId",
                        column: x => x.PhysicianId,
                        principalTable: "Physicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaselineForm_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaselineForm_FormLabelId",
                table: "BaselineForm",
                column: "FormLabelId");

            migrationBuilder.CreateIndex(
                name: "IX_BaselineForm_PhysicianId",
                table: "BaselineForm",
                column: "PhysicianId");

            migrationBuilder.CreateIndex(
                name: "IX_BaselineForm_VisitId",
                table: "BaselineForm",
                column: "VisitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaselineForm");
        }
    }
}
