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
        public IActionResult GetAllCategories()
        {
            var categories = _categoryRepo.GetAll().Select(item => item.AsDto());
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var item = _categoryRepo.GetById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item.AsDto());
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryDto categoryDto)
        {
            //var zeroDate = DateTime.MinValue.AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second).AddMilliseconds(now.Millisecond);
            //int uniqueId = (int)(zeroDate.Ticks / 10000);

            Category item = new()
            {
                Name = categoryDto.Name,
                Url = categoryDto.Url,
                CreatedOn = DateTime.Now,
            };

            _categoryRepo.Insert(item);

            return CreatedAtAction(nameof(GetCategoryById), new { id = item.Id }, item.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id, CategoryDto categoryDto)
        {
            var existingCategory = _categoryRepo.GetById(id);

            if (existingCategory is null)
            {
                return NotFound();
            }

            Category updatedCategory = new Category
            {
                Name = categoryDto.Name,
                Url = categoryDto.Url,
            };

            existingCategory = updatedCategory;

            _categoryRepo.Update(updatedCategory);

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteCategory(int id)
        {
            var existingItem = _categoryRepo.GetById(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            _categoryRepo.Delete(id);

            return Ok();
        }
    }
}
