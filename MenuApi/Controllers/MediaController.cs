using MenuApi.Dtos.Media;
using MenuApi.Entities.Media;
using MenuApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace MenuApi.Controllers
{
    [Route("media")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IRepository<Picture> _pictureRepo;
        public MediaController(IRepository<Picture> pictureRepo)
        {
            _pictureRepo = pictureRepo;
        }

        [HttpGet("GetMedia")]
        public IActionResult GetItems()
        {
            var items = _pictureRepo.GetAll().Select(item => item.AsDto());
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int pictureId)
        {
            var item = _pictureRepo.GetById(pictureId);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item.AsDto());
        }

        [HttpPost]
        public IActionResult CreateItem(PictureDto pictureDto)
        {
            var now = DateTime.Now;
            var zeroDate = DateTime.MinValue.AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second).AddMilliseconds(now.Millisecond);
            int uniqueId = (int)(zeroDate.Ticks / 10000);

            Picture item = new()
            {
                Title = pictureDto.Title,
                FullSizeImageWidth = pictureDto.FullSizeImageWidth,
                FullSizeImageHeight = pictureDto.FullSizeImageHeight,
                Size = pictureDto.Size,
                AlternateText = pictureDto.AlternateText,
                ImageUrl = pictureDto.ImageUrl,
                FullSizeImageUrl = pictureDto.FullSizeImageUrl,
                Id = uniqueId,
                CreatedOn = now,
            };

            _pictureRepo.Insert(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(int PictureId, PictureDto pictureDto)
        {
            var existingItem = _pictureRepo.GetById(PictureId);

            if (existingItem is null)
            {
                return NotFound();
            }

            Picture updatedItem = new Picture
            {
                Title = pictureDto.Title,
                FullSizeImageWidth = pictureDto.FullSizeImageWidth,
                FullSizeImageHeight = pictureDto.FullSizeImageHeight,
                Size = pictureDto.Size,
                AlternateText = pictureDto.AlternateText,
            };

            existingItem = updatedItem;

            _pictureRepo.Update(updatedItem);

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteItem(int pictureId)
        {
            var existingItem = _pictureRepo.GetById(pictureId);

            if (existingItem is null)
            {
                return NotFound();
            }

            _pictureRepo.Delete(pictureId);

            return Ok();
        }

    }
}
