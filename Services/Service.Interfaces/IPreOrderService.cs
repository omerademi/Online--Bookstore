using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Service.Interfaces
{
    public interface IPreOrderService
    {
        void Add(PreOrder preOrder);
        void Edit(PreOrder preOrder);
        void Delete(int id);
        void DeleteByBookId(int bookID);
        void DeleteByUserId(string userID);

        PreOrder GetPreOrderById(int id);
        PreOrder GetPreOrderByBookId(int bookID);
        PreOrder GetPreOderByUserId(string userID);

        IEnumerable<PreOrder> GetAllPreOrders();
        IEnumerable<PreOrder> GetAllPreOrdersByUserId(string userID);
        IEnumerable<PreOrder> GetAllPreOrdersByBookId(string bookID);
        IQueryable<PreOrder> GetAllPreOrdersQueryable();
    }
}
