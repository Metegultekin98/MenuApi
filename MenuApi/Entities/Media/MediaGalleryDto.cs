using System.Collections.Generic;
using System.IO;

namespace MenuApi.Entities.Media
{
    public partial class MediaGalleryDto
    {
        public int Id { get; set; }
        //public IList<FileSystemInfo> Files { get; set; } = new List<FileSystemInfo>();
        public int GalleryStartIndex { get; set; }
        public int ThumbSize { get; set; } = 72;
        public int ImageSize { get; set; } = 600;
        public string ModelName { get; set; }
        public string DefaultAlt { get; set; }
        public bool BoxEnabled { get; set; }
        public bool ImageZoomEnabled { get; set; }
    }
}
