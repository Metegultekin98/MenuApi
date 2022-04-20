using MenuApi.Entities.Media;

namespace MenuApi.Entities.Items
{
    public partial class Items : BaseEntity
    {
        public MediaGallery MediaGallery { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public ItemExtras Extras { get; set; } = new ItemExtras();
    }
}
