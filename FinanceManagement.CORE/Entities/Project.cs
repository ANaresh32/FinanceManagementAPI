using System.ComponentModel.DataAnnotations;

namespace FinanceManagement.CORE.Entities
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ProjectReferenceId { get; set; }
        [Required]
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        [Required]
        public int TeamMembersCount { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
        public ICollection<Timesheet> Timesheets { get; set; }
    }
}
