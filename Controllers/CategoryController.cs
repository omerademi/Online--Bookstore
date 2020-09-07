using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data.Entities;
using BookStore.Logger;
using BookStore.Models;
using BookStore.Services.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStore.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<BooksController> _logger;

        public CategoryController(ICategoryService categoryService, ILogger<BooksController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetCategories();
            if (categories != null)
            {
                _logger.LogInformation(LoggerMessageDisplay.CategoriesListed);
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.NoCategoriesInDB);
            }
            return View(categories);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryViewModel categoryViewModel)
        {
            var category = new Category();
            if (ModelState.IsValid)
            {
                category.Name = categoryViewModel.Name;

                _categoryService.Add(category);
                _logger.LogInformation(LoggerMessageDisplay.CategoryCreated);

                return RedirectToAction(nameof(Index));
            }

            _logger.LogError(LoggerMessageDisplay.CategoryNotCreatedModelStateInvalid);
            return View(category);
        }

        [HttpPost]
        public JsonResult CreateCategoryAJAX(string name)
        {
            var category = new Category();
            
            if (name != "" || name != null)
            {
                category.Name = name;
                _categoryService.Add(category);
            }
            return Json(category);
        }

        // GET: Category/Edit/5
        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Category category)
        {
            if (id != category.Id)
            {
                _logger.LogWarning(LoggerMessageDisplay.NoCategoryFound);
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _categoryService.Edit(category);
                    _logger.LogInformation(LoggerMessageDisplay.CategoryEdited);
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(LoggerMessageDisplay.CategoryEditErrorModelStateInvalid + " ---> " + ex);
                    throw;
                }
                _logger.LogError(LoggerMessageDisplay.CategoryEditErrorModelStateInvalid);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Details/5
        public IActionResult Details(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            _logger.LogInformation(LoggerMessageDisplay.CategoryFoundDisplayDetails);

            if (category == null)
            {
                _logger.LogWarning(LoggerMessageDisplay.NoCategoryFound);
                return NotFound();
            }

            return View(category);
        }

        // GET: Authors/Delete/5
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            //var category = _categoryService.GetCategoryById(id);
            try
            {
                _categoryService.Delete(id);
                _logger.LogInformation(LoggerMessageDisplay.CategoryDeleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerMessageDisplay.CategoryDeletedError+ " ---> " + ex);
                throw;
            }

            _logger.LogError(LoggerMessageDisplay.CategoryDeletedError);
            return RedirectToAction(nameof(Index));
        }
    }
}