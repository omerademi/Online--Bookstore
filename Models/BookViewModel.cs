using BookStore.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class BookViewModel
    {
        // Book Data

        [Display(Name = "Book ID")]
        public int BookID { get; set; }

        [Display(Name = "Title")]
        [StringLength(350)]
        public string Title { get; set; }

        [Display(Name = "Year")]
        public DateTime YearOfIssue { get; set; }

        [Display(Name = "Pages")]
        public int NumberOfPages { get; set; }

        [Display(Name = "User ID")]
        public int UserId { get; set; }

        [Display(Name = "Genre")]
        [StringLength(150)]
        public string Genre { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Book Type")]
        [StringLength(50)]
        public string BookType { get; set; } // EBook, AudioBook, Fisical Book

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Language")]
        [StringLength(50)]
        public string Language { get; set; }

        [Display(Name = "Country")]
        [StringLength(150)]
        public string Country { get; set; }

        [Display(Name = "Edition")]
        public int Edition { get; set; }

        [Display(Name = "Dimensions")]
        [StringLength(50)]
        public string Dimensions { get; set; }

        [Display(Name = "Weight")]
        public double Weight { get; set; }

        [Display(Name = "Copies")]
        public int Copies { get; set; }

        [Display(Name = "Shipping")]
        [StringLength(50)]
        public string Shipping { get; set; }

        [Display(Name = "Photo Cover")]
        public string MainPhotoURL { get; set; }

        [Display(Name = "Photos")]
        public List<Photo> Photos { get; set; }

        // Author Data
        [Display(Name = "Author")]
        [StringLength(350)]
        public string AuthorName { get; set; }

        [Display(Name = "Author ID")]
        public int AuthorID { get; set; }

        [Display(Name = "Author")]
        public Author Author { get; set; }

        [Display(Name = "Authors List")]
        public IEnumerable<SelectListItem> Authors { get; set; }

        public string CreateAuthorName { get; set; }
        public string CreateAuthorShortDescription { get; set; }

        // Publisher Data
        [Display(Name = "Publisher")]
        [StringLength(250)]
        public string PublisherName { get; set; }

        [Display(Name = "Publisher Country")]
        [StringLength(250)]
        public string PublisherCountry { get; set; }

        [Display(Name = "Publisher")]
        public Publisher Publisher { get; set; }

        [Display(Name = "Publisher ID")]
        public int PublisherID { get; set; }

        [Display(Name = "Publihsers")]
        public IEnumerable<SelectListItem> Publishers{ get; set; }

        public string CreatePublisherName { get; set; }
        public string CreatePublisherCountry { get; set; }

        // Category Data
        [Display(Name = "Category ID")]
        public int CategoryID { get; set; }

        [Display(Name = "Categories")]
        public IEnumerable<SelectListItem> Categories { get; set; }

        [Display(Name = "Category")]
        public Category Category { get; set; }

        [Display(Name = "Category")]
        [StringLength(150)]
        public string CategoryName { get; set; }

        public string CreateCategoryName { get; set; }

        // Photos Data
        [Display(Name = "Photo Cover")]
        public string PhotoURL { get; set; }
        public bool IsMainPhoto { get; set; }
        [Display(Name = "Photo Description")]
        public string DescriptionPhoto { get; set; }

        // Wishlist Data
        public double WishlistTotalPrice { get; set; }

        // Shopping Cart Data
        public int AddToCartTotalCounter { get; set; }


        // Other Landing Page Data
        public IEnumerable<Book> TopPopularBooks { get; set; }
        public IEnumerable<Book> TopPopularBooksByBestSellingAuthor { get; set; }
        public Author BestSellingAuthor { get; set; }
        public IEnumerable<Book> AllBooks { get; set; }
        public IEnumerable<Book> AllBooksFromWishlistByLoggedInUser { get; set; }
    }
}
