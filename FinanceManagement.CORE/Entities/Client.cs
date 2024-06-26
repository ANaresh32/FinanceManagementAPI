using System.ComponentModel.DataAnnotations;

namespace FinanceManagement.CORE.Entities
{
    public class Client
    {
        /*public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
        public string ReferenceName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Project> Projects { get; set; }*/
        public Guid Id { get; set; }
        public string  ClientName { get; set; }
        public string ClientEmailId { get; set; }
        public string ClientLocation { get; set; }
        public string ReferenceName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
