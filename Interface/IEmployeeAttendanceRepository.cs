using DynamicStore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicStore.Interface
{
    public interface IEmployeeAttendanceRepository
    {
        Task<IEnumerable<EmployeeAttendance>> GetEmployeeAttendancesByEmployeeIdAsync(int employeeId);
    }
}

