using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DynamicStore.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }

            [ForeignKey("Warehouse")]
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }

        [Required]
        public int InventoryQuantity { get; set; }

        [Required]
        public int InventoryAlertQuantity { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
