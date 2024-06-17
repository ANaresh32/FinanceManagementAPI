using FinanceManagement.CORE.Entities;

namespace FinanceManagement.SERVICES.Interface
{
    public interface ITimesheetService
    {
        Task<IEnumerable<Timesheet>> GetAllTimesheetsAsync();
        Task<Timesheet> GetTimesheetByIdAsync(Guid id);
        Task AddTimesheetAsync(Timesheet timesheet);
        Task UpdateTimesheetAsync(Timesheet timesheet);
        Task DeleteTimesheetAsync(Guid id);
    }
}
