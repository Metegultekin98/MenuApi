using System.Collections.Generic;

namespace MenuApi.Entities.Items
{
    public partial class ItemsTag : BaseEntity
    {
        public string Name { get; set; }
        public IList<Items> ItemList { get; set; }
    }
}
