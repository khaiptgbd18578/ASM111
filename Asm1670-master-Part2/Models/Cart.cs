using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asm1670.Models
{
    public class Cart
    {
        public int Id { get; set; }
        [Range(0, 99, ErrorMessage = "You can only choose 99 items")]
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string Email { get; set; }
        public int OrderQuantity { get; set; }
        public double OrderPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
