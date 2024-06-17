using FinanceManagement.CORE.Entities;
using FinanceManagement.DATA.IRepo;
using FinanceManagement.SERVICES.Interface;

namespace FinanceManagement.SERVICES.Services
{
    public class TimesheetService : ITimesheetService
    {
        private readonly ITimesheetRepository _timesheetRepository;

        public TimesheetService(ITimesheetRepository timesheetRepository)
        {
            _timesheetRepository = timesheetRepository;
        }

        public async Task<IEnumerable<Timesheet>> GetAllTimesheetsAsync() => await _timesheetRepository.GetAllAsync();
        public async Task<Timesheet> GetTimesheetByIdAsync(Guid id) => await _timesheetRepository.GetByIdAsync(id);
        public async Task AddTimesheetAsync(Timesheet timesheet) => await _timesheetRepository.AddAsync(timesheet);
        public async Task UpdateTimesheetAsync(Timesheet timesheet) => await _timesheetRepository.UpdateAsync(timesheet);
        public async Task DeleteTimesheetAsync(Guid id) => await _timesheetRepository.DeleteAsync(id);
    }
}
