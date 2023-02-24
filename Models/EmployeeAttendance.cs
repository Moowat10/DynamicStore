using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DynamicStore.Models
{
    public class EmployeeAttendance
    {
        [Key]
        public int EmployeeAttendanceId { get; set; }

        [Required]
        public DateTime AttendanceDate { get; set; }

        [Required]
        public DateTime ShiftStartTime { get; set; }

        
        public DateTime ShiftEndTime { get; set; }

   
        public bool IsHoliday { get; set; }

        public int HolidayLeft { get; set; }

        public decimal HolidayPenaltyAmount { get; set; }

        public decimal Bonus { get; set; }

        public decimal Loan { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
