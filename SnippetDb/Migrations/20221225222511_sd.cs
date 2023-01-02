using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnippetDb.Migrations
{
  public partial class sd : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DeleteData(
          table: "Tags",
          keyColumn: "Id",
          keyValue: 1);

      migrationBuilder.AlterColumn<string>(
          name: "Name",
          table: "Tags",
          type: "nvarchar(450)",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "nvarchar(max)");



      migrationBuilder.CreateTable(
          name: "RelatedTags",
          columns: table => new
          {
            PrimaryTagId = table.Column<int>(type: "int", nullable: false),
            SecondaryTagId = table.Column<int>(type: "int", nullable: false),
            SecondaryTagId1 = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_RelatedTags", x => new { x.PrimaryTagId, x.SecondaryTagId });
            table.ForeignKey(
                      name: "FK_RelatedTags_Tags_SecondaryTagId",
                      column: x => x.SecondaryTagId,
                      principalTable: "Tags",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);

          });

      migrationBuilder.InsertData(
          table: "Tags",
          columns: new[] { "Id", "Description", "Name" },
          values: new object[] { -1, "Description", "Test Tag" });



      migrationBuilder.CreateIndex(
          name: "IX_RelatedTags_SecondaryTagId",
          table: "RelatedTags",
          column: "SecondaryTagId");


    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "RelatedTags");

      migrationBuilder.DropIndex(
          name: "IX_Tags_Name",
          table: "Tags");

      migrationBuilder.DeleteData(
          table: "Tags",
          keyColumn: "Id",
          keyValue: -1);



      migrationBuilder.AlterColumn<string>(
          name: "Name",
          table: "Tags",
          type: "nvarchar(max)",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "nvarchar(450)");


    }
  }
}
