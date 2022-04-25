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
                FullSizeImageHeight = picture.FullSizeImageHeight,
                FullSizeImageUrl = picture.FullSizeImageUrl,
                FullSizeImageWidth = picture.FullSizeImageWidth,
                ImageUrl = picture.ImageUrl,
                ThumbImageUrl = picture.ThumbImageUrl,
                Size = picture.Size,
                ImageData = picture.ImageData,
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
