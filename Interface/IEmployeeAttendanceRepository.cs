using DynamicStore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicStore.Interface
{
    public interface IEmployeeAttendanceRepository
    {
        Task<IEnumerable<EmployeeAttendance>> GetEmployeeAttendancesAsync();
        Task<EmployeeAttendance> GetEmployeeAttendanceByIdAsync(int id);
        Task<EmployeeAttendance> AddEmployeeAttendanceAsync(EmployeeAttendance employeeAttendance);
        Task<EmployeeAttendance> UpdateEmployeeAttendanceAsync(int id, EmployeeAttendance employeeAttendance);
        Task<bool> DeleteEmployeeAttendanceAsync(int id);
    }
}

