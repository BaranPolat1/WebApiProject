﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Result
{
   public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
