using BookStore.Data.Entities;
using BookStore.Logger;
using BookStore.Repositories.Repository.Interfaces;
using BookStore.Services.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookService> _logger;

        public BookService(IBookRepository bookRepository, ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public void AddBook(Book book)
        {
            _bookRepository.AddBook(book);
            _logger.LogInformation(LoggerMessageDisplay.BookCreated);
        }

        public void DeleteBook(int bookID)
        {
            _bookRepository.DeleteBook(bookID);
        }

        public void EditBook(Book book)
        {
            _bookRepository.EditBook(book);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var result = _bookRepository.GetAllBooks();
            return result;
        }

        public IEnumerable<Book> GetAllBooksByDateAccending()
        {
            var result = _bookRepository.GetAllBooksByDateAccending();
            return result;
        }

        public IEnumerable<Book> GetAllBooksByDateDescending()
        {
            var result = _bookRepository.GetAllBooksByDateDescending();
            return result;
        }

        public IEnumerable<Book> GetAllBooksByGeoLocationCountry(string country)
        {
            var result = _bookRepository.GetAllBooksByGeoLocationCountry(country);
            return result;
        }

        public IEnumerable<Book> GetAllBooksByPriceAccending()
        {
            var result = _bookRepository.GetAllBooksByPriceAccending();
            return result;
        }

        public IEnumerable<Book> GetAllBooksByPriceDescending()
        {
            var result = _bookRepository.GetAllBooksByPriceDescending();
            return result;
        }

        public IEnumerable<Book> GetAllBooksByPublisher(Publisher publisher)
        {
            var result = _bookRepository.GetAllBooksByPublisher(publisher);
            return result;
        }

        public IEnumerable<Book> GetAllBooksByUser(User user)
        {
            var result = _bookRepository.GetAllBooksByUser(user);
            return result;
        }

        public IEnumerable<Book> GetAllBooksByUserId(int userID)
        {
            var result = _bookRepository.GetAllBooksByUserId(userID);
            return result;
        }

        public IEnumerable<Book> GetAllBooksFromToDateByUserId(int userID, DateTime from, DateTime to)
        {
            var result = _bookRepository.GetAllBooksFromToDateByUserId(userID, from, to);
            return result;
        }

        public IQueryable<Book> GetAllBooksQueryable()
        {
            var result = _bookRepository.GetAllBooksQueryable();
            return result;
        }

        public Book GetBookById(int id)
        {
            var result = _bookRepository.GetBookById(id);
            return result;
        }

        public IEnumerable<Book> GetTopPopularBooks()
        {
            var result = _bookRepository.GetTopPopularBooks();
            return result;
        }

        public IEnumerable<Book> TopPopularBooksByBestSellingAuthor(int authorID)
        {
            var result = _bookRepository.GetTopPopularBooksByBestSellingAuthor(authorID);
            return result;
        }
    }
}
