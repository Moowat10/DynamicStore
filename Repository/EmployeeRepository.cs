using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicStore.Data;
using DynamicStore.Interfaces;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            return await _context.Employees.FindAsync(employeeId);
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(int employeeId, Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(employeeId);

            if (existingEmployee != null)
            {
                existingEmployee.EmployeeName = employee.EmployeeName;
                existingEmployee.EmployeeAddress = employee.EmployeeAddress;
                existingEmployee.EmployeePhone = employee.EmployeePhone;
                existingEmployee.EmployeeEmail = employee.EmployeeEmail;
                existingEmployee.EmployeeHireDate = employee.EmployeeHireDate;
                existingEmployee.EmployeeSalary = employee.EmployeeSalary;
                existingEmployee.StoreId = employee.StoreId;
                existingEmployee.UserId = employee.UserId;

                await _context.SaveChangesAsync();
            }

            return existingEmployee;
        }

        public async Task<bool> DeleteEmployeeAsync(int employeeId)
        {
            var existingEmployee = await _context.Employees.FindAsync(employeeId);

            if (existingEmployee != null)
            {
                _context.Employees.Remove(existingEmployee);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }

}
