using System.ComponentModel.DataAnnotations;

namespace FinanceManagement.CORE.Entities
{
    public class EmployeeProject
    {
        [Key]
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Required]
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public decimal BasePrice { get; set; }
        public string PriceType { get; set; }
        public string Currency { get; set; }
    }
}
