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
        private readonly IEmployeeAttendanceRepository _repository;

        public EmployeeAttendanceController(IEmployeeAttendanceRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeAttendance>>> GetEmployeeAttendancesAsync()
        {
            var employeeAttendances = await _repository.GetEmployeeAttendancesAsync();
            return Ok(employeeAttendances);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeAttendance>> GetEmployeeAttendanceByIdAsync(int id)
        {
            var employeeAttendance = await _repository.GetEmployeeAttendanceByIdAsync(id);

            if (employeeAttendance == null)
            {
                return NotFound();
            }

            return Ok(employeeAttendance);
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<IEnumerable<EmployeeAttendance>>> GetEmployeeAttendancesByEmployeeIdAsync(int employeeId)
        {
            var employeeAttendances = await _repository.GetEmployeeAttendanceByIdAsync(employeeId);
            return Ok(employeeAttendances);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeAttendance>> AddEmployeeAttendanceAsync(EmployeeAttendance employeeAttendance)
        {
            var addedEmployeeAttendance = await _repository.AddEmployeeAttendanceAsync(employeeAttendance);
            return CreatedAtAction(nameof(GetEmployeeAttendanceByIdAsync), new { id = addedEmployeeAttendance.EmployeeAttendanceId }, addedEmployeeAttendance);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployeeAttendanceAsync(int id, EmployeeAttendance employeeAttendance)
        {
            if (id != employeeAttendance.EmployeeAttendanceId)
            {
                return BadRequest();
            }

            var existingEmployeeAttendance = await _repository.GetEmployeeAttendanceByIdAsync(id);

            if (existingEmployeeAttendance == null)
            {
                return NotFound();
            }

            // Check for null values before updating
            if (employeeAttendance.AttendanceDate != null)
            {
                existingEmployeeAttendance.AttendanceDate = employeeAttendance.AttendanceDate;
            }

            if (employeeAttendance.ShiftStartTime != null)
            {
                existingEmployeeAttendance.ShiftStartTime = employeeAttendance.ShiftStartTime;
            }

            if (employeeAttendance.ShiftEndTime != null)
            {
                existingEmployeeAttendance.ShiftEndTime = employeeAttendance.ShiftEndTime;
            }

            existingEmployeeAttendance.IsHoliday = employeeAttendance.IsHoliday;

            existingEmployeeAttendance.HolidayLeft = employeeAttendance.HolidayLeft;

            existingEmployeeAttendance.HolidayPenaltyAmount = employeeAttendance.HolidayPenaltyAmount;

            existingEmployeeAttendance.Bonus = employeeAttendance.Bonus;

            existingEmployeeAttendance.Loan = employeeAttendance.Loan;

            await _repository.UpdateEmployeeAttendanceAsync(existingEmployeeAttendance.EmployeeAttendanceId,existingEmployeeAttendance);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployeeAttendanceAsync(int id)
        {
            var existingEmployeeAttendance = await _repository.GetEmployeeAttendanceByIdAsync(id);

            if (existingEmployeeAttendance == null)
            {
                return NotFound();
            }

            await _repository.DeleteEmployeeAttendanceAsync(id);

            return NoContent();
        }
    }
}
