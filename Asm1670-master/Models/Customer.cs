using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asm1670.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(30, ErrorMessage = "Name Author length must be between 3 and 30", MinimumLength = 3)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        public ICollection<Book> Book { get; set; }
    }
}
