using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories.Repository.Interfaces
{
    public interface IShoppingCartRepository
    {
        void Add(ShoppingCart shoppingCart);
        void Delete(int id);
        void DeleteByBookId(int bookID);

        ShoppingCart GetShoppingCartById(int id);

        IEnumerable<ShoppingCart> GetAllItemsInCart();
        IEnumerable<ShoppingCart> GetAllItemsInCartByUserId(string userId);
    }
}
