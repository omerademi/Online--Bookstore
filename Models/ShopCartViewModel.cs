using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class ShopCartViewModel
    {
        // Book Data
        public int BookID { get; set; }
        public string Title { get; set; }
        public DateTime YearOfIssue { get; set; }
        public int NumberOfPages { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public string BookType { get; set; }
        public string Dimensions { get; set; }
        public double Weight { get; set; }
        public string Shipping { get; set; }
        public string MainPhotoURL { get; set; }

        // Author Data
        public string AuthorName { get; set; }
        public int AuthorID { get; set; }

        // Publisher Data
        public string PublisherName { get; set; }
        public string PublisherCountry { get; set; }
        public int PublisherID { get; set; }

        // Category Data
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        // Wishlist Data
        public double WishlistTotalPrice { get; set; }

        // Order Data
        public double SubTotal { get; set; }
        public double ShippingTotal { get; set; }
        public double TotalPrice { get; set; }
        public double AddToCartTotalCounter { get; set; }

        // Other Data
        public IEnumerable<Book> AllBooks { get; set; }
        public IEnumerable<Book> AllBooksFromWishlistByLoggedInUser { get; set; }
        public IEnumerable<Book> AllBooksAddedToCartByLoggedInUser { get; set; }
    }
}
