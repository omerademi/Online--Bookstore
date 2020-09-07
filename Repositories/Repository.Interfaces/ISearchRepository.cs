using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories.Repository.Interfaces
{
    public interface ISearchRepository
    {
        IEnumerable<Book> SearchBooks(List<string> keywords, string title , string author, string category);
        IEnumerable<Book> GetAllBooks();
        Book GetBook(int id);
    }
}
