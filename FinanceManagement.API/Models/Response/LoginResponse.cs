using FinanceManagement.CORE.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace FinanceManagement.API.Models.Response
{
    public class LoginResponse
    {
        public Employee employee { get; set; }
        public string Token { get; set; }
    }
}
