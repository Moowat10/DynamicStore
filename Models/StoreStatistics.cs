using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DynamicStore.Models
{
    public class StoreStatistics
    {
        [Key, ForeignKey("Store")]
        public int StoreId { get; set; }

        public virtual Store Store { get; set; }

        public int total_products { get; set; }

        public int total_categories { get; set; }

        public int total_inventory { get; set; }

        public decimal total_sales { get; set; }

        public int total_orders { get; set; }

    }
}
