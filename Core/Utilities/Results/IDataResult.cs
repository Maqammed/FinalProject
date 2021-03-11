using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    { //Interface interface'i impemetne ederse icindekileri yazmaqa ehtiyac yodu (IResult'un icindekiler burdada var)
         T Data { get; }
    }
}
