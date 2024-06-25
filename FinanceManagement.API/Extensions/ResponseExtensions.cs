using FinanceManagement.CORE.Entities;
using FinanceManagement.API.Models.Response;
namespace FinanceManagement.API.Extensions
{
    public static class ResponseExtensions
    {
        public static Error ToError(this FinanceException ex)
        {
            if (ex != null)
            {
                return new Error
                {
                    Code = ex.ErrorCode,
                    Message = ex.ErrorMessage,
                };
            }

            return null;
        }
    }
}
