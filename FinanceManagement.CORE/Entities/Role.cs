using System.ComponentModel.DataAnnotations;

namespace FinanceManagement.CORE.Entities
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        public string Priority { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
