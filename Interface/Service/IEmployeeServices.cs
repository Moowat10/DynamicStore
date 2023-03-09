using DynamicStore.Models;
using DynamicStore.DTO;

namespace DynamicStore.Interface
{
    public interface IEmployeeServices
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int employeeId);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(int employeeId, UpdateEmployeeDTO employee);
        Task<bool> DeleteEmployeeAsync(int employeeId);
    }
}
