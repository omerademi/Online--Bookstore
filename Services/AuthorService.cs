using BookStore.Data.Entities;
using BookStore.Repositories.Repository.Interfaces;
using BookStore.Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public void Add(Author author)
        {
            _authorRepository.Add(author);
        }

        public void Delete(Author author)
        {
            _authorRepository.Delete(author);
        }

        public void Edit(Author author)
        {
            _authorRepository.Edit(author);
        }

        public Author GetAuthorById(int id)
        {
            var result = _authorRepository.GetAuthorById(id);
            return result;
        }

        public Author GetAuthorByPopularity()
        {
            var result = _authorRepository.GetAuthorByPopularity();
            return result;
        }

        public IEnumerable<Author> GetAuthors()
        {
            var result = _authorRepository.GetAuthors();
            return result;
        }
    }
}
