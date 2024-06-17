namespace FinanceManagement.CORE.Entities
{
    public class Timesheet
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ProjectId { get; set; }
        public DateTime Date { get; set; }
        public decimal HoursWorked { get; set; }
        public string Description { get; set; }
        public Guid? ApprovedById { get; set; }

        public Employee Employee { get; set; }
        public Project Project { get; set; }
        public Employee ApprovedBy { get; set; }
    }
}
