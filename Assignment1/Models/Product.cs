using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName ="money")]
        public decimal Price { get; set; }
    }
}
