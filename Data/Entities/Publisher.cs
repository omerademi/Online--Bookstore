using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Country { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
