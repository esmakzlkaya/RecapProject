using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
       /* bool Success { get; }
        string Message { get; } */ 
       //IResult da zaten var ordan gelsinler

    }
}
