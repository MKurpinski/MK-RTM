using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerTests
{
    public class Result<T>
    {
        private Result(bool success, T data)
        {
            Succeded = success;
            Data = data;
        }

        public bool Succeded { get; set; }
        public T Data { get; set; }

        public static Result<T> Success(T data)
        {
            return new Result<T>(true, data);
        }
        public static Result<T> Failure()
        {
            return new Result<T>(false, default);
        }
    }
}
