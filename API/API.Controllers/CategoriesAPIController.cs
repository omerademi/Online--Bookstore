using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Data.Entities;
using BookStore.Services.Service.Interfaces;

namespace BookStore.API.API.Controllers
{
    [Route("api/CategoriesAPI")]
    [ApiController]
    public class CategoriesAPIController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesAPIController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/CategoriesAPI
        [HttpGet("Categories")]
        public IEnumerable<Category> GetCategories()
        {
            var categories = _categoryService.GetCategories();
            return categories;
        }

        // GET: api/CategoriesAPI/5
        [HttpGet("Category")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = _categoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/CategoriesAPI/5
        [HttpPut("EditCategory")]
        public IActionResult EditCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            try
            {
                _categoryService.Edit(category);
                return Ok(category);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error occured:  {ex}.");
            }
        }

        // POST: api/CategoriesAPI
        [HttpPost("AddCategory")]
        public ActionResult<Category> AddCategory(Category category)
        {
            _categoryService.Add(category);
            return CreatedAtAction("AddCategory", new { id = category.Id }, category);
        }

        // DELETE: api/CategoriesAPI/5
        [HttpDelete("DeleteCategory")]
        public ActionResult<Category> DeleteCategory(int id)
        {
            _categoryService.Delete(id);
            return NoContent(); // return Ok();
        }

    }
}
