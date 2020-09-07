using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Services.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Views.Shared
{
    public class NotificationsModel : PageModel
    {
        private readonly IShoppingCartService _shoppingCartService;

        public NotificationsModel(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public void OnGet()
        {
            var notificationCounters = _shoppingCartService.GetAllItemsInCart().Count();

            ViewData["Counter"] = notificationCounters;
        }
    }
}