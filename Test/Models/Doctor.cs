using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [Range(20,50)]
        public int Age { get; set; }
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }

    }
}
