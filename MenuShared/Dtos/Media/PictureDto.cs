﻿using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MenuShared.Dtos.Media
{
    public class PictureDto : BaseEntityDto
    {
        public int? Size { get; set; }
        public string ThumbImageUrl { get; set; }
        public string ImageUrl { get; set; }
        public string FullSizeImageUrl { get; set; }
        public int? FullSizeImageWidth { get; set; }
        public int? FullSizeImageHeight { get; set; }
        public string Title { get; set; }
        public string AlternateText { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public string ImageData { get; set; }
        public IList<Items.ItemsDto> Items { get; set; }
    }
}
