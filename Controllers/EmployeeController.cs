using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicStore.DTO;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;

        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesAsync()
        {
            var employees = await _employeeServices.GetEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{employeeId}")]
        public async Task<ActionResult<Employee>> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await _employeeServices.GetEmployeeByIdAsync(employeeId);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployeeAsync(Employee employee)
        {
            var newEmployee = await _employeeServices.AddEmployeeAsync(employee);

            return Ok(newEmployee);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeAsync(int employeeId, UpdateEmployeeDTO employee)
        {
            if (employee == null || employeeId != employee.EmployeeId)
            {
                return BadRequest();
            }

            var updatedEmployee = await _employeeServices.UpdateEmployeeAsync(employeeId, employee);

            if (updatedEmployee == null)
            {
                return NotFound();
            }

            return Ok(updatedEmployee);
        }

        [HttpDelete("{employeeId}")]
        public async Task<ActionResult> DeleteEmployeeAsync(int employeeId)
        {
            var result = await _employeeServices.DeleteEmployeeAsync(employeeId);
            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }

}
