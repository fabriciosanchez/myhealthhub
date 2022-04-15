using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myhealthhub.api.Migrations
{
    public partial class AddingBaselineFormAndRelationships2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaselineForm_FormsLabels_FormLabelId",
                table: "BaselineForm");

            migrationBuilder.DropForeignKey(
                name: "FK_BaselineForm_Physicians_PhysicianId",
                table: "BaselineForm");

            migrationBuilder.DropForeignKey(
                name: "FK_BaselineForm_Visits_VisitId",
                table: "BaselineForm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaselineForm",
                table: "BaselineForm");

            migrationBuilder.RenameTable(
                name: "BaselineForm",
                newName: "BaselineForms");

            migrationBuilder.RenameIndex(
                name: "IX_BaselineForm_VisitId",
                table: "BaselineForms",
                newName: "IX_BaselineForms_VisitId");

            migrationBuilder.RenameIndex(
                name: "IX_BaselineForm_PhysicianId",
                table: "BaselineForms",
                newName: "IX_BaselineForms_PhysicianId");

            migrationBuilder.RenameIndex(
                name: "IX_BaselineForm_FormLabelId",
                table: "BaselineForms",
                newName: "IX_BaselineForms_FormLabelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaselineForms",
                table: "BaselineForms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaselineForms_FormsLabels_FormLabelId",
                table: "BaselineForms",
                column: "FormLabelId",
                principalTable: "FormsLabels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaselineForms_Physicians_PhysicianId",
                table: "BaselineForms",
                column: "PhysicianId",
                principalTable: "Physicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaselineForms_Visits_VisitId",
                table: "BaselineForms",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaselineForms_FormsLabels_FormLabelId",
                table: "BaselineForms");

            migrationBuilder.DropForeignKey(
                name: "FK_BaselineForms_Physicians_PhysicianId",
                table: "BaselineForms");

            migrationBuilder.DropForeignKey(
                name: "FK_BaselineForms_Visits_VisitId",
                table: "BaselineForms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaselineForms",
                table: "BaselineForms");

            migrationBuilder.RenameTable(
                name: "BaselineForms",
                newName: "BaselineForm");

            migrationBuilder.RenameIndex(
                name: "IX_BaselineForms_VisitId",
                table: "BaselineForm",
                newName: "IX_BaselineForm_VisitId");

            migrationBuilder.RenameIndex(
                name: "IX_BaselineForms_PhysicianId",
                table: "BaselineForm",
                newName: "IX_BaselineForm_PhysicianId");

            migrationBuilder.RenameIndex(
                name: "IX_BaselineForms_FormLabelId",
                table: "BaselineForm",
                newName: "IX_BaselineForm_FormLabelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaselineForm",
                table: "BaselineForm",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaselineForm_FormsLabels_FormLabelId",
                table: "BaselineForm",
                column: "FormLabelId",
                principalTable: "FormsLabels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaselineForm_Physicians_PhysicianId",
                table: "BaselineForm",
                column: "PhysicianId",
                principalTable: "Physicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaselineForm_Visits_VisitId",
                table: "BaselineForm",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
