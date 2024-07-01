using FinanceManagement.CORE.Entities;
using FinanceManagement.SERVICES.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimesheetsController : ControllerBase
    {
        private readonly ITimesheetService _timesheetService;

        public TimesheetsController(ITimesheetService timesheetService)
        {
            _timesheetService = timesheetService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Timesheet>>> GetAllTimesheets()
        {
            var timesheets = await _timesheetService.GetAllTimesheetsAsync();
            if (timesheets == null)
            {
                return NotFound(new { message = "No timesheet found." });
            }
            return Ok(timesheets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Timesheet>> GetTimesheetById(Guid id)
        {
            var timesheet = await _timesheetService.GetTimesheetByIdAsync(id);
            if (timesheet == null)
            {
                return NotFound(new { message = "No timesheets assigned for provided ID." });
            }
            return Ok(timesheet);
        }

        [HttpPost]
        public async Task<ActionResult<Timesheet>> CreateTimesheet(Timesheet timesheet)
        {
            await _timesheetService.AddTimesheetAsync(timesheet);
            return CreatedAtAction(nameof(GetTimesheetById), new { id = timesheet.Id }, timesheet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTimesheet(Guid id, Timesheet timesheet)
        {
            if (id != timesheet.Id)
            {
                return BadRequest(new { message = "No such time sheet exist." });
            }

            await _timesheetService.UpdateTimesheetAsync(timesheet);
            return Ok(new { message = "TimeSheet updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimesheet(Guid id)
        {
            await _timesheetService.DeleteTimesheetAsync(id);
            return Ok(new { message = "TimeSheet deleted successfully." });
        }
    }
}
