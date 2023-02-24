using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DynamicStore.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

  
        public string ProductDescription { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }

      
    }
}
