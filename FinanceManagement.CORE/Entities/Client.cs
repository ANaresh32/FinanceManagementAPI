using System.ComponentModel.DataAnnotations;

namespace FinanceManagement.CORE.Entities
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public string ReferenceName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
