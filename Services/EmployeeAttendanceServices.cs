using DynamicStore.Interface;
using DynamicStore.Models;

namespace DynamicStore.Services
{
    public class EmployeeAttendanceServices : IEmployeeAttendanceServices
    {
        private readonly IEmployeeAttendanceRepository _employeeAttendanceRepository;

        public EmployeeAttendanceServices(IEmployeeAttendanceRepository employeeAttendanceRepository)
        {
            _employeeAttendanceRepository = employeeAttendanceRepository;
        }

        public async Task<IEnumerable<EmployeeAttendance>> GetEmployeeAttendancesAsync()
        {
            return await _employeeAttendanceRepository.GetAllAsync();
        }

        public async Task<EmployeeAttendance> GetEmployeeAttendanceByIdAsync(int id)
        {
            return await _employeeAttendanceRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<EmployeeAttendance>> GetEmployeeAttendancesByEmployeeIdAsync(int employeeId)
        {
            return await _employeeAttendanceRepository.GetEmployeeAttendancesByEmployeeIdAsync(employeeId);
        }

        public async Task<EmployeeAttendance> AddEmployeeAttendanceAsync(EmployeeAttendance employeeAttendance)
        {
            // Perform any necessary business logic or calculations here before adding the attendance
            return await _employeeAttendanceRepository.AddAsync(employeeAttendance);
        }

        public async Task<EmployeeAttendance> UpdateEmployeeAttendanceAsync(int id, EmployeeAttendance employeeAttendance)
        {
            // Perform any necessary business logic or calculations here before updating the attendance
            return await _employeeAttendanceRepository.UpdateAsync(id, employeeAttendance);
        }

        public async Task<bool> DeleteEmployeeAttendanceAsync(int id)
        {
            // Perform any necessary business logic or calculations here before deleting the attendance
            return await _employeeAttendanceRepository.DeleteAsync(id);
        }
    }
}
