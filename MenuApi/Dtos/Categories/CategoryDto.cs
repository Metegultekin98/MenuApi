using MenuApi.Entities.Media;

namespace MenuApi.Dtos.Categories
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public Picture PictureModel { get; set; } = new Picture();
    }
}
