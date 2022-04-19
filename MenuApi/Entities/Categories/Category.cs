using MenuApi.Entities.Media;

namespace MenuApi.Entities.Categories
{
    public partial class Category : BaseEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Picture PictureModel { get; set; } = new Picture();

    }
}
