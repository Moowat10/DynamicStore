using System.ComponentModel.DataAnnotations;

namespace DynamicStore.Models
{
    public class Warehouse
    {
        [Key]
        public int WarehouseId { get; set; }

        [Required]
        public string WarehouseName { get; set; }

        [Required]
        public string WarehouseAddress { get; set; }

        [Required]
        public string WarehousePhone { get; set; }

        [Required]
        public string WarehouseEmail { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
