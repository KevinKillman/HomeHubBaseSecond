using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnippetDb.Migrations
{
    public partial class SecondaryTagShadowProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Description", "Name", "TagId" },
                values: new object[] { 1, "Description", "Testing", null });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TagId",
                table: "Tags",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Tags_TagId",
                table: "Tags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Tags_TagId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_TagId",
                table: "Tags");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Tags");
        }
    }
}
