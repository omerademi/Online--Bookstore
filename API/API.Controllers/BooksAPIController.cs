using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Data.Entities;
using BookStore.Services.Service.Interfaces;

namespace BookStore.API.API.Controllers
{
    [Route("api/BooksAPI")]
    [ApiController]
    public class BooksAPIController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksAPIController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/BooksAPI
        [HttpGet("Books")]
        public IEnumerable<Book> GetBooks()
        {
            var books = _bookService.GetAllBooks();
            return books;
        }

        // GET: api/BooksAPI/5
        [HttpGet("Book")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _bookService.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/BooksAPI/5
        [HttpPost("EditBook")]
        public IActionResult EditBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            try
            {
                _bookService.EditBook(book);
                return Ok(book);
            }
            catch (Exception ex)
            {
               throw new ArgumentException($"Error occured:  {ex}.");
            }
        }

        // POST: api/BooksAPI
        [HttpPost("AddBook")]
        public ActionResult<Book> AddBook(Book book)
        {
            _bookService.AddBook(book);
            return CreatedAtAction("AddBook", new { id = book.Id }, book);
        }

        // DELETE: api/BooksAPI/5
        [HttpDelete("DeleteBook")]
        public ActionResult<Book> DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
            // 204 No Content is a popular response for DELETE
            // or return Ok();
            return NoContent();
        }

    }
}
