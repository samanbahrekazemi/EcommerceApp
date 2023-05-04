namespace EcommerceApp.Shared.Models
{
    public class Result<T>
    {

        public Result()
        {
            
        }
        public Result(bool succeeded)
        {
            Succeeded = succeeded;
        }
        public bool Succeeded { get; set; }
        public T Data { get; set; }
        public string? Message { get; set; } = string.Empty;
        public ErrorType? ErrorType { get; set; }

        public Result(T data, string? message = null)
        {
            Data = data;
            Message = message;
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>(data, null) { Succeeded = true };
        }

        public static Result<T> Success()
        {
            return new Result<T>(true) ;
        }


        public static Result<T> Failure()
        {
            return new Result<T>(false);
        }

        public static Result<T> Failure(T data)
        {
            return new Result<T>(data, null) { Succeeded = false };
        }
        public static Result<T> Failure(string error , T data)
        {
            return new Result<T>(data, null) { Succeeded = false , Message = error };
        }
    }


    public enum ErrorType
    {
        BadRequest,
        EntityNotFound,
        Forbidden,
        InternalServerError,
        Unauthorized
    }

}
