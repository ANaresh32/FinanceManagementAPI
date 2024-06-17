namespace FinanceManagement.CORE.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
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
