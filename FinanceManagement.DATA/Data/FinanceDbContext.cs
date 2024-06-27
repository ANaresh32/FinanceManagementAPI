using FinanceManagement.CORE.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagement.DATA.Data
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options)
        {
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Employee>()
                .HasOne(e => e.ProjectManager)
                .WithMany(e => e.TeamMembers)
                .HasForeignKey(e => e.ProjectManagerId);*/

            modelBuilder.Entity<EmployeeProject>()
                .HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(ep => ep.EmployeeId);

          /*  modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Project)
                .WithMany(p => p.EmployeeProjects)
                .HasForeignKey(ep => ep.ProjectId);*/

            modelBuilder.Entity<Timesheet>()
                .HasOne(t => t.Employee)
                .WithMany(e => e.Timesheets)
                .HasForeignKey(t => t.EmployeeId);

           /* modelBuilder.Entity<Timesheet>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Timesheets)
                .HasForeignKey(t => t.ProjectId);*/

            modelBuilder.Entity<Timesheet>()
                .HasOne(t => t.ApprovedBy)
                .WithMany(e => e.ApprovedTimesheets)
                .HasForeignKey(t => t.ApprovedById);
        }
    }
}
