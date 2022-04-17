using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemsTagDtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsTagDtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaGalleryDtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GalleryStartIndex = table.Column<int>(type: "int", nullable: false),
                    ThumbSize = table.Column<int>(type: "int", nullable: false),
                    ImageSize = table.Column<int>(type: "int", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultAlt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoxEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ImageZoomEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaGalleryDtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PictureDtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureId = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: true),
                    ThumbImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullSizeImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullSizeImageWidth = table.Column<int>(type: "int", nullable: true),
                    FullSizeImageHeight = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlternateText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureDtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemsDtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaGalleryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsDtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsDtos_MediaGalleryDtos_MediaGalleryId",
                        column: x => x.MediaGalleryId,
                        principalTable: "MediaGalleryDtos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoryDtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryDtos_PictureDtos_PictureModelId",
                        column: x => x.PictureModelId,
                        principalTable: "PictureDtos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDtos_PictureModelId",
                table: "CategoryDtos",
                column: "PictureModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsDtos_MediaGalleryId",
                table: "ItemsDtos",
                column: "MediaGalleryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryDtos");

            migrationBuilder.DropTable(
                name: "ItemsDtos");

            migrationBuilder.DropTable(
                name: "ItemsTagDtos");

            migrationBuilder.DropTable(
                name: "PictureDtos");

            migrationBuilder.DropTable(
                name: "MediaGalleryDtos");
        }
    }
}
