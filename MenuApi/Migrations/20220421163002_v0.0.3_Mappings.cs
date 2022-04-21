using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuApi.Migrations
{
    public partial class v003_Mappings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemExtras_ExtrasId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemsTag_ItemsTagId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_MediaGallery_MediaGalleryId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Picture_MediaGallery_MediaGalleryId",
                table: "Picture");

            migrationBuilder.DropTable(
                name: "MediaGallery");

            migrationBuilder.DropIndex(
                name: "IX_Picture_MediaGalleryId",
                table: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Items_ExtrasId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemsTagId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_MediaGalleryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MediaGalleryId",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "ExtrasId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemsTagId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MediaGalleryId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ItemsId",
                table: "ItemExtras",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemsItemsTag",
                columns: table => new
                {
                    ItemListId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsItemsTag", x => new { x.ItemListId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ItemsItemsTag_Items_ItemListId",
                        column: x => x.ItemListId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsItemsTag_ItemsTag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "ItemsTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemsPicture",
                columns: table => new
                {
                    ItemsId = table.Column<int>(type: "int", nullable: false),
                    PicturesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsPicture", x => new { x.ItemsId, x.PicturesId });
                    table.ForeignKey(
                        name: "FK_ItemsPicture_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsPicture_Picture_PicturesId",
                        column: x => x.PicturesId,
                        principalTable: "Picture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemExtras_ItemsId",
                table: "ItemExtras",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsItemsTag_TagsId",
                table: "ItemsItemsTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsPicture_PicturesId",
                table: "ItemsPicture",
                column: "PicturesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemExtras_Items_ItemsId",
                table: "ItemExtras",
                column: "ItemsId",
                principalTable: "Items",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemExtras_Items_ItemsId",
                table: "ItemExtras");

            migrationBuilder.DropTable(
                name: "ItemsItemsTag");

            migrationBuilder.DropTable(
                name: "ItemsPicture");

            migrationBuilder.DropIndex(
                name: "IX_ItemExtras_ItemsId",
                table: "ItemExtras");

            migrationBuilder.DropColumn(
                name: "ItemsId",
                table: "ItemExtras");

            migrationBuilder.AddColumn<int>(
                name: "MediaGalleryId",
                table: "Picture",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExtrasId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemsTagId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MediaGalleryId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MediaGallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    BoxEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DefaultAlt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    GalleryStartIndex = table.Column<int>(type: "int", nullable: false),
                    ImageSize = table.Column<int>(type: "int", nullable: false),
                    ImageZoomEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbSize = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaGallery", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Picture_MediaGalleryId",
                table: "Picture",
                column: "MediaGalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ExtrasId",
                table: "Items",
                column: "ExtrasId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemsTagId",
                table: "Items",
                column: "ItemsTagId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_MediaGalleryId",
                table: "Items",
                column: "MediaGalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemExtras_ExtrasId",
                table: "Items",
                column: "ExtrasId",
                principalTable: "ItemExtras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemsTag_ItemsTagId",
                table: "Items",
                column: "ItemsTagId",
                principalTable: "ItemsTag",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_MediaGallery_MediaGalleryId",
                table: "Items",
                column: "MediaGalleryId",
                principalTable: "MediaGallery",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_MediaGallery_MediaGalleryId",
                table: "Picture",
                column: "MediaGalleryId",
                principalTable: "MediaGallery",
                principalColumn: "Id");
        }
    }
}
