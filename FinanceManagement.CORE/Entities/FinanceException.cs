using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagement.CORE.Entities
{
    public class FinanceException:Exception
    {
        public FinanceException(string errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}
