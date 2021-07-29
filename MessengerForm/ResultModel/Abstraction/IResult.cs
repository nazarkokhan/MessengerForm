﻿using System;
using System.Collections.Generic;

namespace MessengerForm.ResultModel.Abstraction
{
    public interface IResult
    {
        IReadOnlyCollection<string> Messages { get; }

        bool Success { get; }

        Exception? Exception { get; }
    }
}