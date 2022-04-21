using MenuApi.Entities.Media;
using System.Collections.Generic;

namespace MenuApi.Entities.Categories
{
    public partial class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public Picture PictureModel { get; set; } = new Picture();
        public IList<Items.Items> ItemList { get; set; }
    }
}
