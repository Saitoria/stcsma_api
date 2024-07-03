using SCTSMA.UTILS.Interface;

namespace SCTSMA.UTILS
{
    public class Result<T> : IResult<T>
    {
        public string message { get ; set ; } = string.Empty;
        public bool succeeded { get ; set ; } 
        public T data { get ; set ; }
        public int code { get ; set ; }


        #region Non Async Methods 

        #region Success Methods 

        public static Result<T> Success()
        {
            return new Result<T>
            {
                succeeded = true,
                code = 200
            };
        }

        public static Result<T> Success(string message)
        {
            return new Result<T>
            {
                succeeded = true,
                message = message,
                code = 200
            };
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>
            {
                succeeded = true,
                message = "Successful",
                data = data,
                code = 200
            };
        }

        public static Result<T> Success(T data, string message)
        {
            return new Result<T>
            {
                succeeded = true,
                message = message,
                data = data,
                code = 200
            };
        }

        #endregion

        #region Failure Methods 

        public static Result<T> Failure()
        {
            return new Result<T>
            {
                succeeded = false,
                code = 100
            };
        }
        public static Result<T> Failure(string message)
        {
            return new Result<T>
            {
                succeeded = false,
                message = message,
                code = 100
            };
        }
        public static Result<T> Failure(string message, int code)
        {
            return new Result<T>
            {
                succeeded = false,
                message = message,
                code = code
            };
        }

        public static Result<T> Failure(T data)
        {
            return new Result<T>
            {
                succeeded = false,
                message = "Failed",
                data = data,
                code = 100
            };
        }

        public static Result<T> Failure(T data, string message)
        {
            return new Result<T>
            {
                succeeded = false,
                message = message,
                data = data,
                code = 100
            };
        }

        public static Result<T> Failure(T data, string message, int code)
        {
            return new Result<T>
            {
                succeeded = false,
                message = message,
                data = data,
                code = code
            };
        }

        public static Result<T> Failure(Exception exception)
        {
            return new Result<T>
            {
                succeeded = false,
                message = exception.Message,
                code = 100
            };
        }

        #endregion

        #endregion

        #region Async Methods 

        #region Success Methods 

        public static Task<Result<T>> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public static Task<Result<T>> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
        }

        public static Task<Result<T>> SuccessAsync(T data)
        {
            return Task.FromResult(Success(data));
        }

        public static Task<Result<T>> SuccessAsync(T data, string message)
        {
            return Task.FromResult(Success(data, message));
        }

        #endregion

        #region Failure Methods 

        public static Task<Result<T>> FailureAsync()
        {
            return Task.FromResult(Failure());
        }
        public static Task<Result<T>> FailureAsync(string message)
        {
            return Task.FromResult(Failure(message));
        }

        public static Task<Result<T>> FailureAsync(string message, int code)
        {
            return Task.FromResult(Failure(message, code));
        }

        public static Task<Result<T>> FailureAsync(T data)
        {
            return Task.FromResult(Failure(data));
        }

        public static Task<Result<T>> FailureAsync(T data, string message, int code)
        {
            return Task.FromResult(Failure(data, message, code));
        }

        public static Task<Result<T>> FailureAsync(Exception exception)
        {
            return Task.FromResult(Failure(exception));
        }

        #endregion

        #endregion
    }
}
