using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [StringLength(350)]
        public string BookTitle { get; set; }
        [StringLength(250)]
        public string BookAuthor { get; set; }
        [StringLength(250)]
        public string BookCountry { get; set; }
        [StringLength(250)]
        public string BookPublisher { get; set; }
        [StringLength(150)]
        public string BookCategory { get; set; }
        [StringLength(150)]
        public string BookType { get; set; }
        [StringLength(250)]
        public string BookDimensions { get; set; }
        [StringLength(250)]
        public string BookWeight { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public DateTime RequiredDate { get; set; }
    }
}
