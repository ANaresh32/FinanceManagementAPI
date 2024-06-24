using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceManagement.CORE.Entities
{
    public class Employee
    {
        [Key]
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
        [MaxLength(15)]
        public string MobileNo { get; set; }
        public DateTime DateOfJoining { get; set; }
        public Guid? ProjectManagerId { get; set; }
        public string EmployeeStatus { get; set; }
        public string SkillSets { get; set; }
        public Guid RoleId { get; set; }

        public Role Role { get; set; }
        //public Employee ProjectManager { get; set; }

        public ICollection<Employee> TeamMembers { get; set; } = new List<Employee>();

        public ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();

        public ICollection<Timesheet> Timesheets { get; set; } = new List<Timesheet>();

        [InverseProperty("ApprovedBy")]
        public ICollection<Timesheet> ApprovedTimesheets { get; set; } = new List<Timesheet>();
    }
}
