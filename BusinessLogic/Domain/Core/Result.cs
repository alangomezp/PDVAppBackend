using Azure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.Core
{
    public class Result
    {
        public string Message { get; set; }
        public bool Success { get; set; }

        public Result(string message, bool isSuccess)
        {
            Message = message;
            Success = isSuccess;
        }

        public static Result Failed(string message) => new (message, false);
        public static Result Succeed(string message) => new (message, true);
       
    }
}
