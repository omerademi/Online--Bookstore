using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookStore.Models;
using BookStore.Services.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using BookStore.Data.Entities;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IWishlistService _wishlistService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IShoppingCartService _shoppingCartService;

        public HomeController(
            IBookService bookService,
            IAuthorService authorService,
            IWishlistService wishlistService,
            IHttpContextAccessor httpContextAccessor,
            IShoppingCartService shoppingCartService
            )
        {
            _bookService = bookService;
            _authorService = authorService;
            _wishlistService = wishlistService;
            _httpContextAccessor = httpContextAccessor;
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            var GetTopBooks = _bookService.GetTopPopularBooks();
            var GetPopularAuthor = _authorService.GetAuthorByPopularity();
            var GetTopPopularBooksByBestSellingAuthor = _bookService.TopPopularBooksByBestSellingAuthor(GetPopularAuthor.Id);
            var GetAllBooks = _bookService.GetAllBooks();
            var notificationCounters = _shoppingCartService.GetAllItemsInCart().Count();

            // init book viewmodel
            var bookViewModel = new BookViewModel
            {
                // fill viewmodel data
                TopPopularBooks = GetTopBooks,
                TopPopularBooksByBestSellingAuthor = GetTopPopularBooksByBestSellingAuthor,
                BestSellingAuthor = GetPopularAuthor,
                AllBooks = GetAllBooks,
                AddToCartTotalCounter = notificationCounters
            };

            ViewData["Counter"] = notificationCounters;

            return View(bookViewModel);
        }

        [HttpPost]
        public IActionResult RefreshPartialViewNotification()
        {
            var notificationCounters = _shoppingCartService.GetAllItemsInCart().Count();
            ViewData["Counter"] = notificationCounters;
            return PartialView("Notification");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public int AddToCartNotificationsCounterTest()
        {
            var notificationCounters = _shoppingCartService.GetAllItemsInCart().Count();
            return notificationCounters;
        }

        [HttpPost]
        public JsonResult AddToWishlist(int id)
        {
            // get book
            var getBookById = _bookService.GetBookById(id);

            var CheckIfExistsInWishlist = _wishlistService.GetWishlistByBookId(id);

            if (CheckIfExistsInWishlist == null)
            {
                // get logged in user id
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                // get other data ids
                var bookId = getBookById.Id;
                var publisherId = getBookById.PublisherID;
                var authorId = getBookById.AuthorID;
                var categoryId = getBookById.CategoryID;

                // init wishlist obj
                var wishlist = new Wishlist
                {
                    UserId = userId,
                    BookId = bookId,
                    PublisherId = publisherId,
                    AuthorId = authorId,
                    CategoryId = categoryId,
                    DateAdded = DateTime.Now
                };

                // add to wishlist
                _wishlistService.Add(wishlist);

                return new JsonResult(new { data = wishlist });
            }
            else
            {
                return new JsonResult(new { data = "" });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
