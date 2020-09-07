using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(250)]
        public string Name { get; set; }
        
        public List<Subcategory> Subcategory { get; set; }
    }
}
