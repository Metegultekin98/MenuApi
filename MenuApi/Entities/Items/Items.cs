using MenuApi.Entities.Media;
using System.Collections.Generic;

namespace MenuApi.Entities.Items
{
    public partial class Items : BaseEntity
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public IList<ItemExtras> Extras { get; set; }
        public IList<Categories.Category> Categories { get; set; }
        public IList<ItemsTag> Tags { get; set; }
        public IList<Picture> Pictures { get; set; }

    }
}
