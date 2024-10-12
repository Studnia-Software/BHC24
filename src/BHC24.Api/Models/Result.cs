namespace BHC24.Api.Models;

public abstract class ResultBase
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public StatusCode StatusCode { get; set; } 
}

public class Result : ResultBase
{
    public static Result Ok()
    {
        return new Result
        {
            IsSuccess = true,
            Message = "Request successful",
            StatusCode = StatusCode.Ok
        };
    }
    
    public static Result<T> Ok<T>(T? data)
    {
        return new Result<T>
        {
            Data = data,
            IsSuccess = true,
            Message = "Request successful",
            StatusCode = StatusCode.Ok
        };
    }
    
    public static Result<T> Fail<T>(string message) where T : class
    {
        return new Result<T>
        {
            IsSuccess = false,
            Message = message,
            StatusCode = StatusCode.BadRequest
        };
    }
}

public class Result<T> : ResultBase
{
    public T Data { get; set; } = default!;
    
    public static Result<T> Fail(string message)
    {
        return new Result<T>
        {
            Data = default,
            IsSuccess = false,
            Message = message,
            StatusCode = StatusCode.BadRequest
        };
    }
    
    public static Result<T> NotFound(string entityName)
    {
        return new Result<T>
        {
            Data = default,
            IsSuccess = false,
            Message = $"{entityName} was not found",
            StatusCode = StatusCode.NotFound
        };
    }
}