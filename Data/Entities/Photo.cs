using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
       
        public string Url { get; set; }
        
        [StringLength(250)]
        public string Description { get; set; }
        
        public DateTime DateAdded { get; set; }
        
        public bool IsMain { get; set; }
    }
}
