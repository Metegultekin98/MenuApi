using MenuApi.Dtos.Media;

namespace MenuApi.Dtos.Categories
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public PictureDto PictureModel { get; set; } = new PictureDto();
    }
}
