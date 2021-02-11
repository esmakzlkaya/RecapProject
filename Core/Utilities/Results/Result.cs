using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success,string message):this(success)
        {
            Message = message;
           // Success = success; - kod tekrarı yapmadık, :this(success) ile aşağıdaki ctor u çalıştıracak
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
