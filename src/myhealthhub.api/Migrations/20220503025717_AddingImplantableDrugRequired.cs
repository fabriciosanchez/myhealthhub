using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myhealthhub.api.Migrations
{
    public partial class AddingImplantableDrugRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CausalgiaStatus",
                table: "BaselineForms");

            migrationBuilder.DropColumn(
                name: "ChemotherapyRelatedStatus",
                table: "BaselineForms");

            migrationBuilder.DropColumn(
                name: "DiabeticStatus",
                table: "BaselineForms");

            migrationBuilder.DropColumn(
                name: "ReflexSympatheticDystrophyStatus",
                table: "BaselineForms");

            migrationBuilder.AlterColumn<string>(
                name: "TreatmentForPainStatus",
                table: "BaselineForms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "PostAmputationStatus",
                table: "BaselineForms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "InjectionsInterventionsStatus",
                table: "BaselineForms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "ImplantableDrug",
                table: "BaselineForms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "CausalgiaMuscle",
                table: "BaselineForms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "OtherPainDiagnosis",
                table: "BaselineForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SympatheticDystrophy",
                table: "BaselineForms",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherPainDiagnosis",
                table: "BaselineForms");

            migrationBuilder.DropColumn(
                name: "SympatheticDystrophy",
                table: "BaselineForms");

            migrationBuilder.AlterColumn<bool>(
                name: "TreatmentForPainStatus",
                table: "BaselineForms",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "PostAmputationStatus",
                table: "BaselineForms",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "InjectionsInterventionsStatus",
                table: "BaselineForms",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "ImplantableDrug",
                table: "BaselineForms",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "CausalgiaMuscle",
                table: "BaselineForms",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CausalgiaStatus",
                table: "BaselineForms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ChemotherapyRelatedStatus",
                table: "BaselineForms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DiabeticStatus",
                table: "BaselineForms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReflexSympatheticDystrophyStatus",
                table: "BaselineForms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
