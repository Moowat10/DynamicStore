using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DynamicStore.Models
{
    public class Finance
    {
        [Key]
        public int finance_id { get; set; }

        [ForeignKey("Store")]
        public int StoreId { get; set; }

        public virtual Store Store { get; set; }

        public DateTime finance_date { get; set; }

        public string finance_description { get; set; }

        public decimal finance_amount { get; set; }

        public string finance_type { get; set; }

    }
}
