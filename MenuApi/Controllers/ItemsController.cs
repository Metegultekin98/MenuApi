﻿using MenuShared.Dtos;
using MenuShared.Dtos.Items;
using MenuApi.Entities;
using MenuApi.Entities.Items;
using MenuApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MenuApi.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IRepository<Items> _itemsRepo;
        private readonly IRepository<ItemsTag> _itemsTagRepo;

        public ItemsController(IRepository<Items> itemsRepo, IRepository<ItemsTag> itemsTagRepo)
        {
            _itemsRepo = itemsRepo ?? throw new ArgumentNullException(nameof(itemsRepo));
            _itemsTagRepo = itemsTagRepo ?? throw new ArgumentNullException(nameof(itemsTagRepo));
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _itemsRepo.GetAll().Select(item => item.AsDto());
            return Ok(items);
        }

        [HttpGet("/tags")]
        public IActionResult GetTags()
        {
            var tags = _itemsTagRepo.GetAll().Select(tag => tag.AsDto());
            return Ok(tags);
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            var item = _itemsRepo.GetById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item.AsDto());
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] ItemsDto itemDto)
        {
            var now = DateTime.Now;
            //var zeroDate = DateTime.MinValue.AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second).AddMilliseconds(now.Millisecond);
            //int uniqueId = (int)(zeroDate.Ticks / 10000);

            Items item = new()
            {
                Name = itemDto.Name,
                ShortDescription = itemDto.ShortDescription,
                CreatedOn = now,
            };

            _itemsRepo.Insert(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(int id, [FromBody] ItemsDto itemDto)
        {
            var item = _itemsRepo.GetById(id);

            if (item is null)
            {
                return NotFound();
            }

            //Items updatedItem = new Items
            //{
            //    Name = itemDto.Name,
            //    ShortDescription = itemDto.ShortDescription,
            //    UpdatedOn = DateTime.Now,
            //};

            item.Name = itemDto.Name;
            item.ShortDescription = itemDto.ShortDescription;
            item.UpdatedOn = DateTime.Now;
            item.Categories.Clear();
            item.Categories = itemDto.Categories.Select(x => new Entities.Categories.Category
            {
                Name = x.Name,
                Url = x.Url,
                Id = x.IdDto,
            }).ToList();



            _itemsRepo.Update(item);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(int id)
        {
            var existingItem = _itemsRepo.GetById(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            _itemsRepo.Delete(id);

            return Ok();
        }
    }
}
