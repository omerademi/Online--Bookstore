using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        void Edit(Category category);
        void Delete(int id);
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
    }
}
