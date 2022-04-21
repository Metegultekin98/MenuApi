using System.Collections.Generic;

namespace MenuApi.Dtos.Items
{
    public class ItemsTagDto
    {
        public string Name { get; set; }
        public IList<ItemsDto> ItemList { get; set; }
    }
}
