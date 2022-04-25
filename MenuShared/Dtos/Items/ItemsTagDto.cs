using System.Collections.Generic;

namespace MenuShared.Dtos.Items
{
    public class ItemsTagDto : BaseEntityDto
    {
        public string Name { get; set; }
        public IList<ItemsDto> ItemList { get; set; }
    }
}
