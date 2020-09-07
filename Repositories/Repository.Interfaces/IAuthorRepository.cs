using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories.Repository.Interfaces
{
    public interface IAuthorRepository
    {
        void Add(Author author);
        void Edit(Author author);
        void Delete(Author author);

        IEnumerable<Author> GetAuthors();
        Author GetAuthorById(int id);
        Author GetAuthorByPopularity();
    }
}
