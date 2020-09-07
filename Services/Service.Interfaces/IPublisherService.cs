using BookStore.Data.Entities;
using BookStore.Repositories.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Service.Interfaces
{
    public interface IPublisherService
    {
        void Add(Publisher publisher);
        void Edit(Publisher publisher);
        void Delete(int id);
        IEnumerable<Publisher> GetPublishers();
        Publisher GetPublisherById(int id);
    }
}
