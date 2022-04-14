using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myhealthhub.api.Migrations
{
    public partial class AddingManyToManyForFormsLabelsPerVisits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FormLabelsPerVisits",
                table: "FormLabelsPerVisits");

            migrationBuilder.DropIndex(
                name: "IX_FormLabelsPerVisits_FormLabelId",
                table: "FormLabelsPerVisits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormLabelsPerVisits",
                table: "FormLabelsPerVisits",
                columns: new[] { "FormLabelId", "VisitId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FormLabelsPerVisits",
                table: "FormLabelsPerVisits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormLabelsPerVisits",
                table: "FormLabelsPerVisits",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FormLabelsPerVisits_FormLabelId",
                table: "FormLabelsPerVisits",
                column: "FormLabelId");
        }
    }
}
