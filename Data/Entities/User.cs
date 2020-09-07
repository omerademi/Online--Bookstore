using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(250)]
        public string Username { get; set; }
        
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(50)]
        public string AccountType { get; set; }

        [StringLength(250)]
        public string Country { get; set; }

        [StringLength(150)]
        public string City { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }
       
        public  string Description { get; set; }
        
        public DateTime CreatedOn { get; set; }
        public DateTime LastActive { get; set; }
        
        public string PhotoURL { get; set; }
        
        public bool IsAdmin { get; set; }
       
        public bool IsModerator { get; set; }


        public ICollection<Book> Books { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
