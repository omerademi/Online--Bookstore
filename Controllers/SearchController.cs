using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data.Entities;
using BookStore.Services.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IEnumerable<Book> GetAllBooks()
        {
            var result = _searchService.GetAllBooks();
            return result;
        }

        
        public Book GetBook(int id)
        {
            var result = _searchService.GetBook(id);
            return result;
        }

       
        public JsonResult Search(string keywords, string title, string author, string category)
        {
            List<string> keywordsList = new List<string>();

            if (keywords != "undefined")
            {
                keywordsList = keywords.Split(" ").ToList();
            }

            List<Book> SearchResults = new List<Book>();

            SearchResults = SearchJobPostsBy(keywordsList, title, author, category);

            return Json(new { data = SearchResults });
        }

        #region Helpers

        private List<Book> SearchJobPostsBy(List<string> keywords, string title, string author, string category)
        {
            var result = _searchService.SearchBooks(keywords, title, author, category).ToList();
            return result;
        }

        #endregion
    }
}