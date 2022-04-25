using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemsMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsMap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemsTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediasMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: true),
                    ThumbImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullSizeImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullSizeImageWidth = table.Column<int>(type: "int", nullable: true),
                    FullSizeImageHeight = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlternateText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediasMap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemExtras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ItemsId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemExtras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemExtras_ItemsMap_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "ItemsMap",
                        principalColumn: "Id");
                });

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
                        name: "FK_ItemsItemsTag_ItemsMap_ItemListId",
                        column: x => x.ItemListId,
                        principalTable: "ItemsMap",
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
                name: "CategoryMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureModelId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryMap_MediasMap_PictureModelId",
                        column: x => x.PictureModelId,
                        principalTable: "MediasMap",
                        principalColumn: "Id");
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
                        name: "FK_ItemsPicture_ItemsMap_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "ItemsMap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsPicture_MediasMap_PicturesId",
                        column: x => x.PicturesId,
                        principalTable: "MediasMap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_CategoryItems_CategoryMap_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "CategoryMap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryItems_ItemsMap_ItemListId",
                        column: x => x.ItemListId,
                        principalTable: "ItemsMap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItems_ItemListId",
                table: "CategoryItems",
                column: "ItemListId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMap_PictureModelId",
                table: "CategoryMap",
                column: "PictureModelId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryItems");

            migrationBuilder.DropTable(
                name: "ItemExtras");

            migrationBuilder.DropTable(
                name: "ItemsItemsTag");

            migrationBuilder.DropTable(
                name: "ItemsPicture");

            migrationBuilder.DropTable(
                name: "CategoryMap");

            migrationBuilder.DropTable(
                name: "ItemsTag");

            migrationBuilder.DropTable(
                name: "ItemsMap");

            migrationBuilder.DropTable(
                name: "MediasMap");
        }
    }
}
