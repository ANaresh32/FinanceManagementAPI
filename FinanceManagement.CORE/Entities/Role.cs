namespace FinanceManagement.CORE.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Priority { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
