using DynamicStore.Repository;
using DynamicStore.DTO;
using DynamicStore.Interface;
using DynamicStore.Models;

namespace DynamicStore.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeServices(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            return await _employeeRepository.GetByIdAsync(employeeId);
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.AddAsync(employee);
        }

        public async Task<Employee> UpdateEmployeeAsync(int employeeId, UpdateEmployeeDTO employee)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(employeeId);

            if (existingEmployee == null)
            {
                return null;
            }

            if (employee.EmployeeName != null)
                existingEmployee.EmployeeName = employee.EmployeeName;
            if (employee.EmployeeAddress != null)
                existingEmployee.EmployeeAddress = employee.EmployeeAddress;
            if (employee.EmployeePhone != null)
                existingEmployee.EmployeePhone = employee.EmployeePhone;
            if (employee.EmployeeEmail != null)
                existingEmployee.EmployeeEmail = employee.EmployeeEmail;
            if (employee.EmployeeSalary != null)
                existingEmployee.EmployeeSalary = (decimal)employee.EmployeeSalary;
            
            if (employee.UserId != null)
                existingEmployee.UserId = (int)employee.UserId;

            return await _employeeRepository.UpdateAsync(employeeId, existingEmployee);
        }

        public async Task<bool> DeleteEmployeeAsync(int employeeId)
        {   
            return await _employeeRepository.DeleteAsync(employeeId);
        }
    }
}
