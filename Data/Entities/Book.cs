﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
       
        [StringLength(350)]
        public string Title { get; set; }

        [StringLength(350)]
        public string AuthorName { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }

        public DateTime YearOfIssue { get; set; }
       
        public int NumberOfPages { get; set; }

        [StringLength(350)]
        public string PublisherName { get; set; }
        public Publisher Publisher { get; set; }
        public int PublisherID { get; set; }

        public int UserId { get; set; }
      
        [StringLength(150)]
        public string Genre { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
     
        [StringLength(150)]
        public string CategoryName { get; set; }
     
        public double Price { get; set; }
      
        [StringLength(50)]
        public string BookType { get; set; } // EBook, AudioBook, Fisical Book
      
        public string Description { get; set; }
       
        [StringLength(50)]
        public string Language { get; set; }

        [StringLength(150)]
        public string Country { get; set; }

        public int Edition { get; set; }
     
        [StringLength(50)]
        public string Dimensions { get; set; }
     
        public double Weight { get; set; }
      
        public int Copies { get; set; }
     
        [StringLength(50)]
        public string Shipping { get; set; }

        public string PhotoURL { get; set; }

        public int SoldItems { get; set; }

        public ICollection<Photo> Photos { get; set; }
    }
}
