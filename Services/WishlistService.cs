using BookStore.Data.Entities;
using BookStore.Repositories.Repository.Interfaces;
using BookStore.Services.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IWishlistRepository _wishlistRepository;
        private UserManager<IdentityUser> _userManager;

        public WishlistService(
            IBookRepository bookRepository,
            IWishlistRepository wishlistRepository,
            UserManager<IdentityUser> userManager)
        {
            _bookRepository = bookRepository;
            _wishlistRepository = wishlistRepository;
            _userManager = userManager;
        }

        public void Add(Wishlist wishlist)
        {
            _wishlistRepository.Add(wishlist);
        }

        public void Delete(int id)
        {
            _wishlistRepository.Delete(id);
        }

        public void DeleteByBookId(int bookID)
        {
            _wishlistRepository.DeleteByBookId(bookID);
        }

        public void Edit(Wishlist wishlist)
        {
            _wishlistRepository.Edit(wishlist);
        }

        public IEnumerable<Wishlist> GetAllWishlistByUserId(string userId)
        {
            var result = _wishlistRepository.GetAllWishlistByUserId(userId);
            return result;
        }

        public IEnumerable<Wishlist> GetAllWishlists()
        {
            var result = _wishlistRepository.GetAllWishlists();
            return result;
        }

        public Wishlist GetWishlistByBookId(int bookID)
        {
            var result = _wishlistRepository.GetWishlistByBookId(bookID);
            return result;
        }

        public Wishlist GetWishlistById(int id)
        {
            var result = _wishlistRepository.GetWishlistById(id);
            return result;
        }
    }
}
