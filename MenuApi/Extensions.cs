using MenuApi.Dtos;
using MenuApi.Dtos.Categories;
using MenuApi.Dtos.Items;
using MenuApi.Dtos.Media;
using MenuApi.Entities;
using MenuApi.Entities.Categories;
using MenuApi.Entities.Items;
using MenuApi.Entities.Media;

namespace MenuApi
{
    public static class Extensions
    {
        /// <summary>
        /// Converts an item to a Data Transfer Object
        /// </summary>
        /// <param name="item"></param>
        /// <returns>ItemsDto</returns>
        public static ItemsDto AsDto(this Items item)
        {
            return new ItemsDto
            {
                ItemId = item.Id,
                Name = item.Name,
                ShortDescription = item.ShortDescription,
            };
        }

        /// <summary>
        /// Converts an category to a Data Transfer Object.
        /// </summary>
        /// <param name="category"></param>
        /// <returns>CategoryDto</returns>
        public static CategoryDto AsDto(this Category category)
        {
            return new CategoryDto
            {
                Name = category.Name,
                PictureModel = category.PictureModel,
                Url = category.Url,
            };
        }

        /// <summary>
        /// Converts an picture to a Data Transfer Object.
        /// </summary>
        /// <param name="picture"></param>
        /// <returns>PictureDto</returns>
        public static PictureDto AsDto(this Picture picture)
        {
            return new PictureDto
            {
                Title = picture.Title,
                AlternateText = picture.AlternateText,
                PictureId = picture.PictureId,
                FullSizeImageHeight = picture.FullSizeImageHeight,
                FullSizeImageUrl = picture.FullSizeImageUrl,
                FullSizeImageWidth = picture.FullSizeImageWidth,
                ImageUrl = picture.ImageUrl,
                ThumbImageUrl = picture.ThumbImageUrl,
                Size = picture.Size,
            };
        }
    }
}
