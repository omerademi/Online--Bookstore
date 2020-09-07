using BookStore.Data;
using BookStore.Data.Entities;
using BookStore.Logger;
using BookStore.Repositories.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<BookRepository> _logger;

        public BookRepository(DataContext context, ILogger<BookRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddBook(Book book)
        {
            try {
                _context.Books.Add(book);
                _context.SaveChanges();
                _logger.LogInformation(LoggerMessageDisplay.BookCreated);
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerMessageDisplay.BookEditNotFound, ex);
            }      
        }

        public void DeleteBook(int bookID)
        {
            Book book = GetBookById(bookID);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public void EditBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var result = _context.Books.AsEnumerable();
            return result;
        }

        public IEnumerable<Book> GetAllBooksByDateAccending()
        {
            var result = _context.Books.AsEnumerable().OrderBy(x => x.YearOfIssue);
            return result;
        }

        public IEnumerable<Book> GetAllBooksByDateDescending()
        {
            var result = _context.Books.AsEnumerable().OrderByDescending(x => x.YearOfIssue);
            return result;
        }

        public IEnumerable<Book> GetAllBooksByGeoLocationCountry(string country)
        {
            var result = _context.Books.AsEnumerable().Where(x => x.Country == country);
            return result;
        }

        public IEnumerable<Book> GetAllBooksByPriceAccending()
        {
            var result = _context.Books.AsEnumerable().OrderBy(x => x.Price);
            return result;
        }

        public IEnumerable<Book> GetAllBooksByPriceDescending()
        {
            var result = _context.Books.AsEnumerable().OrderByDescending(x => x.Price);
            return result;
        }

        public IEnumerable<Book> GetAllBooksByPublisher(Publisher publisher)
        {
            var result = _context.Books.AsEnumerable().Where(x => x.Publisher == publisher);
            return result;
        }

        public IEnumerable<Book> GetAllBooksByUser(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooksByUserId(int userId)
        {
            var result = _context.Books.AsEnumerable().Where(x => x.UserId == userId);
            return result;
        }

        public IEnumerable<Book> GetAllBooksForWishlist()
        {
            var result = _context.Books.AsEnumerable();
            return result;
        }

        public IEnumerable<Book> GetAllBooksFromToDateByUserId(int userId, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Book> GetAllBooksQueryable()
        {
            var result = _context.Books.AsQueryable();
            return result;
        }

        public Book GetBookById(int id)
        {
            var result = _context.Books.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public IEnumerable<Book> GetTopPopularBooks()
        {
            var result = _context.Books.AsEnumerable().OrderByDescending(x => x.SoldItems).Take(6);
            return result;
        }

        public IEnumerable<Book> GetTopPopularBooksByBestSellingAuthor(int authorId)
        {
            var result = _context.Books.AsEnumerable().Where(x => x.AuthorID == authorId);
            return result;
        }
    }
}
