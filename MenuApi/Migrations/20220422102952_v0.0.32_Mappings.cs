using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuApi.Migrations
{
    public partial class v0032_Mappings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MediaGalleryId",
                table: "Picture",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemsTagId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryItems",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ItemListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItems", x => new { x.CategoriesId, x.ItemListId });
                    table.ForeignKey(
                        name: "FK_CategoryItems_Category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryItems_Items_ItemListId",
                        column: x => x.ItemListId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Picture_MediaGalleryId",
                table: "Picture",
                column: "MediaGalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemsTagId",
                table: "Items",
                column: "ItemsTagId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItems_ItemListId",
                table: "CategoryItems",
                column: "ItemListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemsTag_ItemsTagId",
                table: "Items",
                column: "ItemsTagId",
                principalTable: "ItemsTag",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_MediaGallery_MediaGalleryId",
                table: "Picture",
                column: "MediaGalleryId",
                principalTable: "MediaGallery",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemsTag_ItemsTagId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Picture_MediaGallery_MediaGalleryId",
                table: "Picture");

            migrationBuilder.DropTable(
                name: "CategoryItems");

            migrationBuilder.DropIndex(
                name: "IX_Picture_MediaGalleryId",
                table: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemsTagId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MediaGalleryId",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "ItemsTagId",
                table: "Items");
        }
    }
}
