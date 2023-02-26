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
    public class EmployeeAttendanceRepository : IEmployeeAttendanceRepository
    {
        private readonly DataContext _dbContext;

        public EmployeeAttendanceRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<EmployeeAttendance>> GetEmployeeAttendancesAsync()
        {
            return await _dbContext.EmployeeAttendance.ToListAsync();
        }

        public async Task<EmployeeAttendance> GetEmployeeAttendanceByIdAsync(int id)
        {
            return await _dbContext.EmployeeAttendance.FirstOrDefaultAsync(e => e.EmployeeAttendanceId == id);
        }

        public async Task<EmployeeAttendance> AddEmployeeAttendanceAsync(EmployeeAttendance employeeAttendance)
        {
            await _dbContext.EmployeeAttendance.AddAsync(employeeAttendance);
            await _dbContext.SaveChangesAsync();

            return employeeAttendance;
        }

        public async Task<EmployeeAttendance> UpdateEmployeeAttendanceAsync(int id, EmployeeAttendance employeeAttendance)
        {
            var existingAttendance = await _dbContext.EmployeeAttendance.FindAsync(id);

            if (existingAttendance != null)
            {
                existingAttendance.AttendanceDate = employeeAttendance.AttendanceDate;
                existingAttendance.ShiftStartTime = employeeAttendance.ShiftStartTime;
                existingAttendance.ShiftEndTime = employeeAttendance.ShiftEndTime;
                existingAttendance.IsHoliday = employeeAttendance.IsHoliday;
                existingAttendance.HolidayLeft = employeeAttendance.HolidayLeft;
                existingAttendance.HolidayPenaltyAmount = employeeAttendance.HolidayPenaltyAmount;
                existingAttendance.Bonus = employeeAttendance.Bonus;
                existingAttendance.Loan = employeeAttendance.Loan;

                await _dbContext.SaveChangesAsync();
            }

            return existingAttendance;
        }

        public async Task<bool> DeleteEmployeeAttendanceAsync(int id)
        {
            var existingAttendance = await _dbContext.EmployeeAttendance.FindAsync(id);

            if (existingAttendance != null)
            {
                _dbContext.EmployeeAttendance.Remove(existingAttendance);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
