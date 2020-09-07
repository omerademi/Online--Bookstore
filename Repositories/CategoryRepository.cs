using BookStore.Data;
using BookStore.Data.Entities;
using BookStore.Repositories.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Category category = GetCategoryById(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public void Edit(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            var result = _context.Categories.AsEnumerable();
            return result;
        }

        public Category GetCategoryById(int id)
        {
            var result = _context.Categories.FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
