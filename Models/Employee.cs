using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DynamicStore.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public string EmployeeAddress { get; set; }

        [Required]
        public string EmployeePhone { get; set; }

        [Required]
        public string EmployeeEmail { get; set; }

        [Required]
        public DateTime EmployeeHireDate { get; set; }

        [Required]
        public decimal EmployeeSalary { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }      

        public ICollection<EmployeeAttendance> EmployeeAttendances { get; set; }
    }
}
