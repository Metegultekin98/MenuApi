﻿using MenuShared.Dtos.Media;
using System.Collections.Generic;

namespace MenuShared.Dtos.Items
{
    public class ItemsDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public IList<ItemExtrasDto> Extras { get; set; }
        public IList<Categories.CategoryDto> Categories { get; set; }
        public IList<ItemsTagDto> Tags { get; set; }
        public IList<PictureDto> Pictures { get; set; }
    }
}
