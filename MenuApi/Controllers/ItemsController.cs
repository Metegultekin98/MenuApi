using MenuApi.Dtos;
using MenuApi.Dtos.Items;
using MenuApi.Entities;
using MenuApi.Entities.Items;
using MenuApi.Repositories;
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

        public ItemsController(IRepository<Items> itemsRepo)
        {
            _itemsRepo = itemsRepo ?? throw new ArgumentNullException(nameof(itemsRepo));
        }

        [HttpGet("GetItems")]
        public IActionResult GetItems()
        {
            var items = _itemsRepo.GetAll().Select(item => item.AsDto());
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int itemId)
        {
            var item = _itemsRepo.GetById(itemId);

            if(item == null)
            {
                return NotFound();
            }

            return Ok(item.AsDto());
        }

        [HttpPost]
        public IActionResult CreateItem(ItemsDto itemDto)
        {
            var now = DateTime.Now;
            var zeroDate = DateTime.MinValue.AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second).AddMilliseconds(now.Millisecond);
            int uniqueId = (int)(zeroDate.Ticks / 10000);

            Items item = new()
            {
                Name = itemDto.Name,
                ShortDescription = itemDto.ShortDescription,
                Id = uniqueId,
                CreatedOn = now,
            };

            _itemsRepo.Insert(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id}, item.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(int itemId, ItemsDto itemDto)
        {
            var existingItem = _itemsRepo.GetById(itemId);

            if(existingItem is null)
            {
                return NotFound();
            }

            Items updatedItem = new Items
            {
                Name = itemDto.Name,
                ShortDescription= itemDto.ShortDescription,
            };

            existingItem = updatedItem;

            _itemsRepo.Update(updatedItem);

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteItem(int itemId)
        {
            var existingItem = _itemsRepo.GetById(itemId);

            if (existingItem is null)
            {
                return NotFound();
            }

            _itemsRepo.Delete(itemId);

            return Ok();
        }
    }
}
