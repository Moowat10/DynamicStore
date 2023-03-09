using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DynamicStore.Models
{
    public class Revenue
    {
        [Key]
        [Obsolete("This property is for internal use only.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Date field is required.")]
        [Display(Name = "Revenue Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        [StringLength(255)]
        [Display(Name = "Revenue Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Amount field is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The Amount field must be a positive number.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Revenue Amount")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "The Type field is required.")]
        [Display(Name = "Revenue Type")]
        public RevenueType Type { get; set; }

        [ForeignKey("StoreId")]
        public int StoreId { get; set; }

    }

    public enum RevenueType
    {
        Sale,
        Service,
        Other
    }
}
