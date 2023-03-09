using System.ComponentModel.DataAnnotations;

namespace DynamicStore.DTO
{
    public class UpdateEmployeeDTO
    {
        [Required]
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeAddress { get; set; }

        public string EmployeePhone { get; set; }

        [EmailAddress]
        public string EmployeeEmail { get; set; }

        public decimal? EmployeeSalary { get; set; }

        public int? StoreId { get; set; }

        public int? UserId { get; set; }
    }
}
