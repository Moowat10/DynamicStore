using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicStore.Repository
{
    public class EmployeeAttendanceRepository : Repository<EmployeeAttendance>, IEmployeeAttendanceRepository
    {
    
        public EmployeeAttendanceRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EmployeeAttendance>> GetEmployeeAttendancesByEmployeeIdAsync(int employeeId)
        {
            return await this._context.EmployeeAttendance.Where( x => x.EmployeeId == employeeId).ToListAsync();
        }
        

    }
}
