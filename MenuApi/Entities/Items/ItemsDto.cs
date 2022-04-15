using MenuApi.Entities.Media;

namespace MenuApi.Entities.Items
{
    public partial class ItemsDto
    {
        public MediaGalleryDto MediaGallery { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
    }
}
