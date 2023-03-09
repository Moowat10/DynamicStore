using DynamicStore.Models;

namespace DynamicStore.Interface
{
    public interface IEmployeeAttendanceRepository
    {
        Task<IEnumerable<EmployeeAttendance>> GetEmployeeAttendancesByEmployeeIdAsync(int employeeId);
    }
}

