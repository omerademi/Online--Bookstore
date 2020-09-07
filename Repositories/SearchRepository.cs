using BookStore.Data;
using BookStore.Data.Entities;
using BookStore.Repositories.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private readonly DataContext _context;

        public SearchRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var result = _context.Books.AsEnumerable();
            return result;
        }

        public Book GetBook(int id)
        {
            var result = _context.Books.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public IEnumerable<Book> SearchBooks(List<string> keywords, string title, string author, string category)
        {
            List<Book> books = new List<Book>();

            IQueryable<Book> booksQueryableList = Enumerable.Empty<Book>().AsQueryable();

            if (keywords.Count > 0)
            {
                foreach (string item in keywords)
                {
                    var book = _context.Books.ToList().Where(
                                    x => x.Title.Contains(item, StringComparison.OrdinalIgnoreCase) ||
                                    x.CategoryName.Contains(item, StringComparison.OrdinalIgnoreCase) ||
                                    x.AuthorName.Contains(item, StringComparison.OrdinalIgnoreCase)
                                  ).DefaultIfEmpty();

                    if (book != null)
                    {
                        books.AddRange(book);
                    }
                }
            }
            else
            {
                books = _context.Books.ToList();
            }

            // check other criterias  
            books = CheckSearchCriteria(books, title, author, category).ToList();

            return books.Distinct().OrderBy(x => x.Id);
        }


        #region Helpers and Private Methods

        private IEnumerable<Book> CheckSearchCriteria(List<Book> BookList, string title, string author, string category)
        {
            List<Book> booksCriteria = new List<Book>();

            if ((title == "undefined" || title == null) && (author == "undefined" || author == null) && (category == "undefined" || category == null) )
            {
                return BookList;
            }

            // title / author / category
            if (title != "undefined" || title != null && author != "undefined" || author != null && category != "undefined" || category != null)
            {
                booksCriteria = BookList.FindAll(x => x.Title == title);
                booksCriteria = booksCriteria.FindAll(x => x.AuthorName == author);
                booksCriteria = booksCriteria.FindAll(x => x.CategoryName == category);
            }

            // title and author
            if (title != "undefined" || title != null && author != "undefined" || author != null && category == null || category == "undefined")
            {
                booksCriteria = BookList.FindAll(x => x.Title == title);
                booksCriteria = booksCriteria.FindAll(x => x.AuthorName == author);
            }

            // author and category
            if (author != "undefined" || author != null && category != "undefined" || category != null && title == "undefined" || title == null)
            {
                booksCriteria = BookList.FindAll(x => x.AuthorName == author);
                booksCriteria = booksCriteria.FindAll(x => x.CategoryName == category);
            }

            // title and category
            if (title != "undefined" || title != null && category == "undefined" || category == null)
            {
                booksCriteria = BookList.FindAll(x => x.Title == title);
                booksCriteria = BookList.Where(x => x.CategoryName == category).ToList();
            }

            // only title
            if (title != "undefined" || title != null && ((author == "undefined" || author == null) && (category == "undefined" || category == null)))
            {
                booksCriteria = BookList.FindAll(x => x.Title == title);
            }

            // only author
            if (author != "undefined" || author != null && ((title == "undefined" || title == null) && (category == "undefined" || category == null)))
            {
                booksCriteria = BookList.FindAll(x => x.AuthorName == author);
            }

            // only category
            if (category != "undefined" || category != null && ((author == "undefined" || author == null) && (title == "undefined" || title == null)))
            {
                booksCriteria = BookList.Where(x => x.CategoryName == category).ToList();
            }

            return booksCriteria;
        }

        #endregion
    }
}
