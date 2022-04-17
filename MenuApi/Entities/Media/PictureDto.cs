﻿using System.IO;

namespace MenuApi.Entities.Media
{
    public partial class PictureDto
    {
        public int Id { get; set; }
        public int PictureId { get; set; }
        public int? Size { get; set; }
        public string ThumbImageUrl { get; set; }
        public string ImageUrl { get; set; }
        public string FullSizeImageUrl { get; set; }
        public int? FullSizeImageWidth { get; set; }
        public int? FullSizeImageHeight { get; set; }
        public string Title { get; set; }
        public string AlternateText { get; set; }
        //public FileSystemInfo File { get; set; }
    }
}
