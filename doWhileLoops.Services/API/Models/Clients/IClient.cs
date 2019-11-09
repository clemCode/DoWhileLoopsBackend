using System;
using System.Collections.Generic;
using System.Text;

namespace doWhileLoops.Services.API.Models
{
    public interface IClient<TResult> where TResult : IResult
    {
        string BaseAddress { get; set; }

        //IResult GetData();

        TResult GetData();
    }
}
