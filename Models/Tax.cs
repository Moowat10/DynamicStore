using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DynamicStore.Models
{
    public enum TaxType
    {
        [Display(Name = "Income Tax")]
        IncomeTax,
        [Display(Name = "Sales Tax")]
        SalesTax,
        [Display(Name = "Property Tax")]
        PropertyTax
    }

    public class Tax
    {
        [Key]
        [Obsolete("This property is for internal use only.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Date field is required.")]
        [Display(Name = "Tax Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "The Type field is required.")]
        [Display(Name = "Tax Type")]
        public TaxType Type { get; set; }

        [Required(ErrorMessage = "The Amount field is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The Amount field must be a positive number.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Tax Amount")]
        public decimal Amount { get; set; }

        [Obsolete("This property is for internal use only.")]
        public int StoreId { get; set; }

        [ForeignKey("StoreId")]
        [Display(Name = "Store")]
        public virtual Store Store { get; set; }
    }
}
