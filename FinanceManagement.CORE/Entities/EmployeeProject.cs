namespace FinanceManagement.CORE.Entities
{
    public class EmployeeProject
    {
        public Guid EmployeeId { get; set; }
        public Guid ProjectId { get; set; }
        public decimal BasePrice { get; set; }
        public string PriceType { get; set; }
        public string Currency { get; set; }

        public Employee Employee { get; set; }
        public Project Project { get; set; }
    }
}
