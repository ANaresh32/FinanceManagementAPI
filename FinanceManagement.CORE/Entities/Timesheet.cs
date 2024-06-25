using System.ComponentModel.DataAnnotations;

namespace FinanceManagement.CORE.Entities
{
    public class Timesheet
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid EmployeeId { get; set; }
        [Required]
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
