using MenuApi.Dtos.Media;
using MenuApi.Entities.Media;
using MenuApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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

        //[HttpGet("GetMedia")]
        //public IActionResult GetAllMedia()
        //{
        //    var items = _pictureRepo.GetAll().Select(item => item.AsDto());
        //    return Ok(items);
        //}

        //[HttpPost("Upload")]
        //public IActionResult UploadFile(IFormFile file)
        //{
        //    if (file == null)
        //    {
        //        return BadRequest();
        //    }
        //    string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"MenuApi\MenuApi\MediaStorage");
        //    string filePath = Path.Combine(directoryPath, file.FileName);
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        file.CopyTo(stream);
        //    }

        //    return Ok("Upload Successful");
        //}
        //private byte[] GetByteArrayFromImage(IFormFile file)
        //{
        //    using (var target = new MemoryStream())
        //    {
        //        file.CopyTo(target);
        //        return target.ToArray();
        //    }
        //}

        [HttpGet("{pictureId}")]
        public IActionResult GetMediaById(int id)
        {
            var item = _pictureRepo.GetById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item.AsDto());
        }

        [HttpPost("CreateMedia")]
        public IActionResult CreateMedia([FromForm] PictureDto pictureDto)
        {
            //var zeroDate = DateTime.MinValue.AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second).AddMilliseconds(now.Millisecond);
            //int uniqueId = (int)(zeroDate.Ticks / 10000);

            //var bytePic = GetByteArrayFromImage(pictureDto.File);

            byte[] bytes = pictureDto.File.GetBytes();
            var hexString = Convert.ToBase64String(bytes);

            Picture item = new()
            {
                Title = pictureDto.Title,
                FullSizeImageWidth = pictureDto.FullSizeImageWidth,
                FullSizeImageHeight = pictureDto.FullSizeImageHeight,
                Size = pictureDto.Size,
                AlternateText = pictureDto.AlternateText,
                ImageUrl = pictureDto.ImageUrl,
                FullSizeImageUrl = pictureDto.FullSizeImageUrl,
                CreatedOn = DateTime.Now,
                ImageData = hexString,
            };


            _pictureRepo.Insert(item);

            return CreatedAtAction(nameof(CreateMedia), new { id = item.Id }, item.AsDto());

        }

        //[HttpPut("{id}")]
        //public ActionResult UpdateMedia(int PictureId, PictureDto pictureDto)
        //{
        //    var existingMedia = _pictureRepo.GetById(PictureId);

        //    if (existingMedia is null)
        //    {
        //        return NotFound();
        //    }

        //    Picture updatedMedia = new Picture
        //    {
        //        Title = pictureDto.Title,
        //        FullSizeImageWidth = pictureDto.FullSizeImageWidth,
        //        FullSizeImageHeight = pictureDto.FullSizeImageHeight,
        //        Size = pictureDto.Size,
        //        AlternateText = pictureDto.AlternateText,
        //        UpdatedOn=DateTime.Now,
        //    };

        //    existingMedia = updatedMedia;

        //    _pictureRepo.Update(updatedMedia);

        //    return NoContent();
        //}

        [HttpDelete("DeleteMedia/{id}")]
        public ActionResult DeleteMedia(int id)
        {
            var existingMedia = _pictureRepo.GetById(id);

            if (existingMedia is null)
            {
                return NotFound();
            }

            _pictureRepo.Delete(id);

            return Ok();
        }

    }
}
