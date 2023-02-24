using System.ComponentModel.DataAnnotations;
using System.Security;

namespace DynamicStore.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }

        [Required]
        public string StoreName { get; set; }

  
        public string? StoreDescription { get; set; }

        [Required]
        [Obsolete]
        public string StorePhone { get; set; }

        [Required]
        [Obsolete]
        public string StoreEmail { get; set; }

        [Required]
        public string StoreAddress { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Product>? Products { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<StorePermission> Permissions { get; set; }

        public virtual ICollection<Finance> Finances { get; set; }

    }
}