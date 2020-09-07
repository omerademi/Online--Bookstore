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
    [Route("api/AuthorsAPI")]
    [ApiController]
    public class AuthorsAPIController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsAPIController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: api/AuthorsAPI
        [HttpGet("Authors")]
        public IEnumerable<Author> GetAuthors()
        {
            var authors = _authorService.GetAuthors();
            return authors;
        }

        // GET: api/AuthorsAPI/5
        [HttpGet("Author")]
        public IActionResult GetAuthor(int id)
        {
            var author = _authorService.GetAuthorById(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        // PUT: api/AuthorsAPI/5
        [HttpPost("EditAuthor")]
        public IActionResult EditAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            try
            {
                _authorService.Edit(author);
                return Ok(author);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error occured:  {ex}.");
            }
        }

        // POST: api/AuthorsAPI
        [HttpPost("AddAuthor")]
        public ActionResult<Author> CreateAuthor(Author author)
        {
            _authorService.Add(author);
            //return StatusCode(201);
            return CreatedAtAction("AddAuthor", new { id = author.Id }, author);
        }

        // DELETE: api/AuthorsAPI/5
        [HttpDelete("DeleteAuthor")]
        public ActionResult<Author> DeleteAuthor(int id)
        {
            var getAuthorById = _authorService.GetAuthorById(id);
            
            if (getAuthorById == null)
            {
                return NotFound();
            }

            _authorService.Delete(getAuthorById);

            return getAuthorById;
        }

    }
}
