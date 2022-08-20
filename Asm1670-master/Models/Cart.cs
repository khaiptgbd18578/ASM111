using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asm1670.Models
{
    public class Cart
    {
        public int Id { get; set; }


        [Range(0, 99, ErrorMessage = "You can only choose 99 items")]
        public int Amount { get; set; }

        public ICollection<Book> Book { get; set; }
    }
}
