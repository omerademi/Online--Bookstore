using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BookStore.Data.Entities;
using BookStore.Models;
using BookStore.Services.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IWishlistService _wishlistService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IShoppingCartService _shoppingCartService;

        public ShopCartController(
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

        // GET: ShopCart
        public ActionResult Index()
        {
            // init new array of books
            List<Book> AllBookListFromCartByLoggedInUser = new List<Book>();
            var TotalPriceCount = 0.0;
            var TotalShipping = 0.0;
            var NotificationCounter = 0;

            // get logged in user id
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var itemsInCart = _shoppingCartService.GetAllItemsInCartByUserId(userId);

            foreach (var item in itemsInCart)
            {
                var book = _bookService.GetBookById(item.BookId);
                if (book != null)
                {
                    AllBookListFromCartByLoggedInUser.Add(book);
                }
            }

            TotalPriceCount = TotalShipping + Math.Round(AllBookListFromCartByLoggedInUser.Sum(x => x.Price), 2);
            NotificationCounter = _shoppingCartService.GetAllItemsInCart().Count();

            var shopCartViewModel = new ShopCartViewModel()
            {
                SubTotal = Math.Round(AllBookListFromCartByLoggedInUser.Sum(x => x.Price), 2),
                ShippingTotal = 0.0,
                TotalPrice = TotalPriceCount,
                AllBooksAddedToCartByLoggedInUser = AllBookListFromCartByLoggedInUser,
                AddToCartTotalCounter = NotificationCounter
            };

            ViewData["Counter"] = NotificationCounter;

            return View(shopCartViewModel);
        }

        public JsonResult AddToCart(int id)
        {
            // get book
            var getBookById = _bookService.GetBookById(id);
            // get logged in user id
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            // get other data ids
            var bookId = getBookById.Id;
            var publisherId = getBookById.PublisherID;
            var authorId = getBookById.AuthorID;
            var categoryId = getBookById.CategoryID;

            // init shopping cart obj
            var shoppingCart = new ShoppingCart
            {
                UserId = userId,
                BookId = bookId,
                Price = getBookById.Price,
                DateAdded = DateTime.Now
            };

            // add to shopping cart
            _shoppingCartService.Add(shoppingCart);

            return new JsonResult(new { data = shoppingCart });
        }

 
        [HttpPost]
        public JsonResult Delete(int Id)
        {
            var getBook = _bookService.GetBookById(Id);

            _shoppingCartService.DeleteByBookId(Id);
            // ~/ShopCart/Index
            return new JsonResult(new { data = getBook, url = Url.Action("Index", "ShopCart") });
        }

        public IActionResult Buy()
        {
            return RedirectToAction("Index", "Order");
        }

        // POST: ShopCart/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}