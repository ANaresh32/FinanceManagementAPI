namespace FinanceManagement.API.Models.Response
{
    public class ItemsResponse:ResponseBase
    {
        public IEnumerable<Object> Items { get; set; }
    }
}
