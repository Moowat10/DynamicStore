using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeAttendanceController : ControllerBase
    {
        private readonly IEmployeeAttendanceServices _employeeAttendanceServices;

        public EmployeeAttendanceController(IEmployeeAttendanceServices EmployeeAttendanceServices)
        {
            _employeeAttendanceServices = EmployeeAttendanceServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeAttendance>>> GetEmployeeAttendancesAsync()
        {
            var employeeAttendances = await _employeeAttendanceServices.GetEmployeeAttendancesAsync();
            return Ok(employeeAttendances);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeAttendance>> GetEmployeeAttendanceByIdAsync(int id)
        {
            var employeeAttendance = await _employeeAttendanceServices.GetEmployeeAttendanceByIdAsync(id);

            if (employeeAttendance == null)
            {
                return NotFound();
            }

            return Ok(employeeAttendance);
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<IEnumerable<EmployeeAttendance>>> GetEmployeeAttendancesByEmployeeIdAsync(int employeeId)
        {
            var employeeAttendances = await _employeeAttendanceServices.GetEmployeeAttendancesByEmployeeIdAsync(employeeId);
            return Ok(employeeAttendances);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeAttendance>> AddEmployeeAttendanceAsync(EmployeeAttendance employeeAttendance)
        {
            var addedEmployeeAttendance = await _employeeAttendanceServices.AddEmployeeAttendanceAsync(employeeAttendance);
            return Ok(addedEmployeeAttendance);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeAttendance>> UpdateEmployeeAttendanceAsync(int id, EmployeeAttendance employeeAttendance)
        {
            if (id != employeeAttendance.EmployeeAttendanceId)
            {
                return BadRequest();
            }

            var updatedEmployeeAttendance = await _employeeAttendanceServices.UpdateEmployeeAttendanceAsync(id, employeeAttendance);

            if (updatedEmployeeAttendance == null)
            {
                return NotFound();
            }

            return Ok(updatedEmployeeAttendance);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployeeAttendanceAsync(int id)
        {
            var existingEmployeeAttendance =  await _employeeAttendanceServices.DeleteEmployeeAttendanceAsync(id);

            if (!existingEmployeeAttendance)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
