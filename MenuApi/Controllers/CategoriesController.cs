using MenuApi.Dtos.Categories;
using MenuApi.Entities.Categories;
using MenuApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace MenuApi.Controllers
{
    [Route("category")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IRepository<Category> _categoryRepo;
        public CategoriesController(IRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet("GetCategories")]
        public IActionResult GetItems()
        {
            var items = _categoryRepo.GetAll().Select(item => item.AsDto());
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int categoryId)
        {
            var item = _categoryRepo.GetById(categoryId);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item.AsDto());
        }

        [HttpPost]
        public IActionResult CreateItem(CategoryDto categoryDto)
        {
            var now = DateTime.Now;
            var zeroDate = DateTime.MinValue.AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second).AddMilliseconds(now.Millisecond);
            int uniqueId = (int)(zeroDate.Ticks / 10000);

            Category item = new()
            {
                Name = categoryDto.Name,
                Url = categoryDto.Url,
                Id = uniqueId,
                CreatedOn = now,
            };

            _categoryRepo.Insert(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(int categoryId, CategoryDto categoryDto)
        {
            var existingItem = _categoryRepo.GetById(categoryId);

            if (existingItem is null)
            {
                return NotFound();
            }

            Category updatedItem = new Category
            {
                Name = categoryDto.Name,
                Url = categoryDto.Url,
            };

            existingItem = updatedItem;

            _categoryRepo.Update(updatedItem);

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteItem(int categoryId)
        {
            var existingItem = _categoryRepo.GetById(categoryId);

            if (existingItem is null)
            {
                return NotFound();
            }

            _categoryRepo.Delete(categoryId);

            return Ok();
        }
    }
}
