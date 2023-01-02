using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnippetDb.Migrations
{
  public partial class Related : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<string>(
          name: "Description",
          table: "Tags",
          type: "nvarchar(max)",
          nullable: false,
          defaultValue: "");

      migrationBuilder.CreateTable(
          name: "RelatedTags",
          columns: table => new
          {
            TagId = table.Column<int>(type: "int", nullable: false),
            SecondTagId = table.Column<int>(type: "int", nullable: false),
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_RelatedTags", x => new { x.TagId, x.SecondTagId });
            table.ForeignKey(
                      name: "FK_RelatedTags_Tags_SecondTagId",
                      column: x => x.SecondTagId,
                      principalTable: "Tags",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.NoAction);
            table.ForeignKey(
                      name: "FK_RelatedTags_Tags_TagId",
                      column: x => x.TagId,
                      principalTable: "Tags",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.NoAction);
          });

      migrationBuilder.UpdateData(
          table: "Tags",
          keyColumn: "Id",
          keyValue: 1,
          column: "Description",
          value: "Description");


    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "RelatedTags");


    }
  }
}
