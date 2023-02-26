using DynamicStore.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DynamicStoreBackend.Models
{
    public enum PayrollCategory
    {
        [Display(Name = "Regular Salary")]
        RegularSalary,
        [Display(Name = "Overtime Pay")]
        OvertimePay,
        [Display(Name = "Bonuses")]
        Bonuses
    }

    public class Payroll
    {
        [Key]
        [Obsolete("This property is for internal use only.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Date field is required.")]
        [Display(Name = "Payroll Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "The Employee field is required.")]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        [Display(Name = "Employee")]
        public virtual Employee Employee { get; set; }

        [Required(ErrorMessage = "The Category field is required.")]
        [Display(Name = "Payroll Category")]
        public PayrollCategory Category { get; set; }

        [Required(ErrorMessage = "The Amount field is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The Amount field must be a positive number.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Payroll Amount")]
        public decimal Amount { get; set; }

        [Obsolete("This property is for internal use only.")]
        public int StoreId { get; set; }

        [ForeignKey("StoreId")]
        [Display(Name = "Store")]
        public virtual Store Store { get; set; }
    }
}
