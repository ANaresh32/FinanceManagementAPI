namespace FinanceManagement.CORE.Entities
{
    public class Project
    {
        /* public Guid Id { get; set; }
         public string Name { get; set; }
         public string Description { get; set; }
         public DateTime StartDate { get; set; }
         public DateTime? EndDate { get; set; }
         public string ProjectReferenceId { get; set; }
         public Guid ClientId { get; set; }
         public int TeamMembersCount { get; set; }
         public DateTime CreatedAt { get; set; }
         public DateTime UpdatedAt { get; set; }

         public Client Client { get; set; }
         public ICollection<EmployeeProject> EmployeeProjects { get; set; }
         public ICollection<Timesheet> Timesheets { get; set; }*/
        public Guid Id { get; set; }
        public string? ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
       
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? ProjectRefId { get; set; }
        public string ClientEmail { get; set; }
       
        public string ProjectType { get; set; }
      
        public int? Progress { get; set; }
        public int? TeamSize { get; set; }
       
        public string? ProjectManager { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
