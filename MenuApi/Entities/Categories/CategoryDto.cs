using MenuApi.Entities.Media;

namespace MenuApi.Entities.Categories
{
    public partial class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public PictureDto PictureModel { get; set; } = new PictureDto();

    }
}
