using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Text.Json.Serialization;

namespace EcommerceApp.Shared.Models
{
    public class Result<T>
    {
        private static class DefaultMessages
        {
            public const string Success = "operation completed succeeded!";
            public const string Failure = "operation failed!";
        }
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

        public Result(T data, string? message = null)
        {
            Data = data;
            Message = message;
        }

        public static Result<T> Success()
        {
            return new Result<T>() { Succeeded = true, Message = DefaultMessages.Success };
        }

        public static Result<T> Success(T data, string? message = null)
        {
            return new Result<T>() { Succeeded = true , Data = data , Message = message ?? DefaultMessages.Success };
        }

        public static Result<T> Success(string? message = null)
        {
            return new Result<T>() { Succeeded = true, Message = message ?? DefaultMessages.Success };
        }

        public static Result<T> Failure()
        {
            return new Result<T>() { Message = DefaultMessages.Failure };
        }

        public static Result<T> Failure(string? message = null)
        {
            return new Result<T>() { Message = message ?? DefaultMessages.Failure };
        }
      
        public static Result<T> Failure(T data, string? message = null)
        {
            return new Result<T>() { Data = data, Message = message ?? DefaultMessages.Failure };
        }
    }
}
