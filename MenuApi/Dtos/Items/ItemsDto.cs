using MenuApi.Dtos.Media;

namespace MenuApi.Dtos.Items
{
    public class ItemsDto
    {
        public MediaGalleryDto MediaGallery { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public ItemExtrasDto Extras { get; set; } = new ItemExtrasDto();
    }
}
