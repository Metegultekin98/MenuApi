using MenuApi.Dtos;
using MenuApi.Dtos.Items;
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
        public IActionResult GetItem(int id)
        {
            var item = _itemsRepo.GetById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item.AsDto());
        }

        [Authorize]
        [HttpPost("CreateItem")]
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

        [Authorize]
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
            _itemsRepo.Update(item);

            return NoContent();
        }

        [Authorize]
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
