using MenuShared.Dtos.Media;
using System.Collections.Generic;

namespace MenuShared.Dtos.Categories
{
    public class CategoryDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public PictureDto PictureModel { get; set; } = new PictureDto();
        public IList<Items.ItemsDto> ItemList { get; set; }
    }
}
