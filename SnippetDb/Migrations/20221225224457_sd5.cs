using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnippetDb.Migrations
{
  public partial class sd5 : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "RelatedTags",
          columns: table => new
          {
            RelatedTagsId = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            PrimaryTagId = table.Column<int>(type: "int", nullable: false),
            SecondaryTagId = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_RelatedTags", x => x.RelatedTagsId);
            table.ForeignKey(
                      name: "FK_RelatedTags_Tags_PrimaryTagId",
                      column: x => x.PrimaryTagId,
                      principalTable: "Tags",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.NoAction);
            table.ForeignKey(
                      name: "FK_RelatedTags_Tags_SecondaryTagId",
                      column: x => x.SecondaryTagId,
                      principalTable: "Tags",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.NoAction);
          });

      migrationBuilder.CreateIndex(
          name: "IX_RelatedTags_PrimaryTagId",
          table: "RelatedTags",
          column: "PrimaryTagId");

      migrationBuilder.CreateIndex(
          name: "IX_RelatedTags_SecondaryTagId",
          table: "RelatedTags",
          column: "SecondaryTagId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "RelatedTags");
    }
  }
}
