using BookStore.Data;
using BookStore.Data.Entities;
using BookStore.Repositories.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Order order)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteByBookId(int bookID)
        {
            throw new NotImplementedException();
        }

        public void DeleteByUserId(string userID)
        {
            throw new NotImplementedException();
        }

        public void Edit(Order order)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllOrdersByBookId(string bookID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllOrdersByUserId(string userID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> GetAllOrdersQueryable()
        {
            throw new NotImplementedException();
        }

        public Order GetOderByUserId(string userID)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderByBookId(int bookID)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
