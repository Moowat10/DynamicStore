using DynamicStore.Models;

namespace DynamicStore.Interface
{
    public interface IEmployeeAttendanceRepository : IRepository<EmployeeAttendance>
    {
        Task<IEnumerable<EmployeeAttendance>> GetEmployeeAttendancesByEmployeeIdAsync(int employeeId);
    }
}

