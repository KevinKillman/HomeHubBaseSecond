using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnippetDb.Migrations
{
    public partial class sd4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelatedTags");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                    table.ForeignKey(
                        name: "FK_RelatedTags_Tags_SecondaryTagId1",
                        column: x => x.SecondaryTagId1,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelatedTags_SecondaryTagId",
                table: "RelatedTags",
                column: "SecondaryTagId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedTags_SecondaryTagId1",
                table: "RelatedTags",
                column: "SecondaryTagId1");
        }
    }
}
