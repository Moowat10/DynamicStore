using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DynamicStore.Models
{
    public enum ExpenseType
    {
        Payroll,
        Tax,
        Others
    }

    public class Expense
    {
        [Key]
        [Obsolete("This property is for internal use only.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Date field is required.")]
        [Display(Name = "Expense Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        [StringLength(255)]
        [Display(Name = "Expense Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Amount field is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The Amount field must be a positive number.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Expense Amount")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "The Type field is required.")]
        [Display(Name = "Expense Type")]
        public ExpenseType Type { get; set; }

        [Obsolete("This property is for internal use only.")]
        public int StoreId { get; set; }

        [ForeignKey("StoreId")]
        [Display(Name = "Store")]
        public virtual Store Store { get; set; }
    }
}
