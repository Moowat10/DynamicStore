using DynamicStore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicStore.Interface
{
    public interface IEmployeeAttendanceServices
    {
        Task<IEnumerable<EmployeeAttendance>> GetEmployeeAttendancesAsync();
        Task<IEnumerable<EmployeeAttendance>> GetEmployeeAttendancesByEmployeeIdAsync(int employeeId);
        Task<EmployeeAttendance> GetEmployeeAttendanceByIdAsync(int id);
        Task<EmployeeAttendance> AddEmployeeAttendanceAsync(EmployeeAttendance employeeAttendance);
        Task<EmployeeAttendance> UpdateEmployeeAttendanceAsync(int id, EmployeeAttendance employeeAttendance);
        Task<bool> DeleteEmployeeAttendanceAsync(int id);
    }
}

