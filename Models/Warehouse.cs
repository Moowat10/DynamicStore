using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicStore.Models
{
    public class Warehouse
    {
        [Key]
        public int WarehouseId { get; set; }

        [ForeignKey("Store")]
        public int StoreId { get; set; }

        public virtual Store Store { get; set; }
        
        [Required]
        public string WarehouseName { get; set; }

        [Required]
        public string WarehouseAddress { get; set; }
        
        [Required]
        public string WarehouseGeolocation { get; set; }

        [Required]
        public string WarehousePhone { get; set; }

        [Required]
        public string WarehouseEmail { get; set; }

        [Required]
        public double LengthInMeters { get; set; } // in meters

        [Required]
        public double WidthInMeters { get; set; } // in meters
        
        public int TotalCapacity { get; set; }

        public int InventoriesCount { get; set; }

        public int AvailableCapacity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerSquareFoot { get; set; }
        public bool IsAvailable { get; set; }

        // Navigation properties
        public virtual ICollection<WarehouseImage> Images { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
    public class WarehouseImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] ImageData { get; set; }

        [Required]
        public string ContentType { get; set; }

        // Foreign key property
        public int WarehouseId { get; set; }

        // Navigation property
        public virtual Warehouse Warehouse { get; set; }
    }
}
