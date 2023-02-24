using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DynamicStore.DTO
{
    public class NewEmployeeDTO
    {
        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public string EmployeeAddress { get; set; }

        [Required]
        public string EmployeePhone { get; set; }

        [Required]
        [EmailAddress]
        public string EmployeeEmail { get; set; }

        [Required]
        public DateTime EmployeeHireDate { get; set; }

        [Required]
        public decimal EmployeeSalary { get; set; }

        [Required]
        public int StoreId { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
