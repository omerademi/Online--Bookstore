using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Service.Interfaces
{
    public interface IWishlistService
    {       
        void Add(Wishlist wishlist);
        void Edit(Wishlist wishlist);
        void Delete(int id);
        void DeleteByBookId(int bookID);
        Wishlist GetWishlistById(int id);
        Wishlist GetWishlistByBookId(int bookID);
        IEnumerable<Wishlist> GetAllWishlists();
        IEnumerable<Wishlist> GetAllWishlistByUserId(string userId);     
    }
}
