using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DynamicStore.Models
{
    public class StorePermission
    {
        [Key]
        public int PermissionId { get; set; }

        [Required]
        public bool CanAddProducts { get; set; }

        [Required]
        public bool CanEditProducts { get; set; }

        [Required]
        public bool CanDeleteProducts { get; set; }

        [Required]
        public bool CanViewOrders { get; set; }

        [Required]
        public bool CanEditOrders { get; set; }

        [Required]
        public bool CanAddEmployees { get; set; }

        [Required]
        public bool CanEditEmployees { get; set; }

        [Required]
        public bool CanDeleteEmployees { get; set; }

        [ForeignKey("Store")]
        public int StoreId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
