using System.ComponentModel.DataAnnotations;

namespace FinanceManagement.CORE.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        [Required]
        public string EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public string MobileNo { get; set; }
        public DateTime DateOfJoining { get; set; }
        public Guid? ProjectManagerId { get; set; }
        public string EmployeeStatus { get; set; }
        public string SkillSets { get; set; }
        public Guid RoleId { get; set; }

        public Role Role { get; set; }
        public Employee ProjectManager { get; set; }
        public ICollection<Employee> TeamMembers { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
        public ICollection<Timesheet> Timesheets { get; set; }
        public ICollection<Timesheet> ApprovedTimesheets { get; set; }
    }
}
