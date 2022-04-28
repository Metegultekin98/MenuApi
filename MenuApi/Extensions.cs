using MenuShared.Dtos;
using MenuShared.Dtos.Categories;
using MenuShared.Dtos.Items;
using MenuShared.Dtos.Media;
using MenuApi.Entities;
using MenuApi.Entities.Categories;
using MenuApi.Entities.Items;
using MenuApi.Entities.Media;
using MenuApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

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
                IdDto = item.Id,
                Name = item.Name,
                ShortDescription = item.ShortDescription,
                UpdatedOnDto = item.UpdatedOn,
                ActiveDto = item.Active,
                CreatedOnDto = item.CreatedOn,
                DeletedDto = item.Deleted,
            };
        }

        /// <summary>
        /// Converts an item extras to a Data Transfer Object
        /// </summary>
        /// <param name="itemTag"></param>
        /// <returns>ItemsTagDto</returns>
        public static ItemsTagDto AsDto(this ItemsTag itemTag)
        {
            return new ItemsTagDto
            {
                IdDto = itemTag.Id,
                UpdatedOnDto= itemTag.UpdatedOn,
                Name = itemTag.Name,
                CreatedOnDto= itemTag.CreatedOn,
                DeletedDto= itemTag.Deleted,
                ActiveDto= itemTag.Active,
            };
        }

        /// <summary>
        /// Converts an item extras to a Data Transfer Object
        /// </summary>
        /// <param name="itemTag"></param>
        /// <returns>ItemsTagDto</returns>
        public static ItemExtrasDto AsDto(this ItemExtras itemExtra)
        {
            return new ItemExtrasDto
            {
                IdDto= itemExtra.Id,
                ActiveDto = itemExtra.Active,
                DeletedDto= itemExtra.Deleted,
                CreatedOnDto = itemExtra.CreatedOn,
                UpdatedOnDto = itemExtra.UpdatedOn,
                Name= itemExtra.Name,
                Price = itemExtra.Price,
                Total = itemExtra.Total,
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
                IdDto = category.Id,
                Name = category.Name,
                Url = category.Url,
                DeletedDto = category.Deleted,
                CreatedOnDto = category.CreatedOn,
                ActiveDto = category.Active,
                UpdatedOnDto = category.UpdatedOn,
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
                FullSizeImageHeight = picture.FullSizeImageHeight,
                FullSizeImageUrl = picture.FullSizeImageUrl,
                FullSizeImageWidth = picture.FullSizeImageWidth,
                ImageUrl = picture.ImageUrl,
                ThumbImageUrl = picture.ThumbImageUrl,
                Size = picture.Size,
                ImageData = picture.ImageData,
                ActiveDto = picture.Active,
                DeletedDto= picture.Deleted,
                CreatedOnDto= picture.CreatedOn,
                UpdatedOnDto= picture.UpdatedOn,
                IdDto = picture.Id,
            };
        }

        public static byte[] GetBytes(this IFormFile formFile)
        {
            using var memoryStream = new MemoryStream();
            formFile.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

        public static void RegisterRepo(this IServiceCollection services)
        {
            var serviceList = new List<Type>()
            {
                typeof(IRepository<>),
                typeof(Repository<>),
            };

            var assembly = Assembly.GetEntryAssembly();
            assembly = Assembly.Load(assembly.GetName());

            foreach (var serviceType in serviceList)
            {
                foreach (var item in assembly.DefinedTypes.Where(x => x.ImplementedInterfaces.Any(d => d.Name == serviceType.Name) && !x.IsAbstract))
                {
                    services.AddScoped(item);
                    if (!item.Name.ToLower().Contains("base") && !item.Name.Contains("IRepo"))
                        services.AddTransient(item);
                }
            }
        }
    }
}
