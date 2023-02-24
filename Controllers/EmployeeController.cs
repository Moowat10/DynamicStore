using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicStore.DTO;
using DynamicStore.Interfaces;
using DynamicStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesAsync()
        {
            var employees = await _employeeRepository.GetEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{employeeId}")]
        public async Task<ActionResult<Employee>> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployeeAsync(Employee employee)
        {
            var newEmployee = await _employeeRepository.AddEmployeeAsync(employee);

            return CreatedAtAction(nameof(GetEmployeeByIdAsync), new { employeeId = newEmployee.UserId }, newEmployee);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeAsync(int employeeId, UpdateEmployeeDTO employee)
        {
            if (employee == null || employeeId != employee.EmployeeId)
            {
                return BadRequest();
            }

            var existingEmployee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);

            if (existingEmployee == null)
            {
                return NotFound();
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
            if (employee.StoreId != null)
                existingEmployee.StoreId = (int)employee.StoreId;
            if (employee.UserId != null)
                existingEmployee.UserId = (int)employee.UserId;

            var updatedEmployee = await _employeeRepository.UpdateEmployeeAsync(employeeId, existingEmployee);

            return Ok(updatedEmployee);
        }

        [HttpDelete("{employeeId}")]
        public async Task<ActionResult> DeleteEmployeeAsync(int employeeId)
        {
            var result = await _employeeRepository.DeleteEmployeeAsync(employeeId);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
