using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories.Repository.Interfaces
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        void EditBook(Book book);
        void DeleteBook(int bookID);

        Book GetBookById(int id);

        IEnumerable<Book> GetAllBooks();
        IQueryable<Book> GetAllBooksQueryable();

       
        IEnumerable<Book> GetAllBooksByUser(User user);
        IEnumerable<Book> GetAllBooksByUserId(int userId);
        IEnumerable<Book> GetAllBooksByDateDescending();
        IEnumerable<Book> GetAllBooksByDateAccending();
        IEnumerable<Book> GetAllBooksFromToDateByUserId(int userId, DateTime from, DateTime to);
        IEnumerable<Book> GetAllBooksByPriceAccending();
        IEnumerable<Book> GetAllBooksByPriceDescending();
        IEnumerable<Book> GetAllBooksByGeoLocationCountry(string country);
        IEnumerable<Book> GetAllBooksByPublisher(Publisher publisher);
        IEnumerable<Book> GetAllBooksForWishlist();
        IEnumerable<Book> GetTopPopularBooks();
        IEnumerable<Book> GetTopPopularBooksByBestSellingAuthor(int authorId);
    }
}
