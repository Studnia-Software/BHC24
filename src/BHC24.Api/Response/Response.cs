namespace BHC24.Api.Response;

public class Response
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public StatusCode StatusCode { get; set; }
    
    public static Response Ok()
    {
        return new Response
        {
            IsSuccess = true,
            Message = "Request successful",
            StatusCode = StatusCode.Ok
        };
    }
    
    public static Response<T> Ok<T>(T data) where T : class
    {
        return new Response<T>
        {
            Data = data,
            IsSuccess = true,
            Message = "Request successful",
            StatusCode = StatusCode.Ok
        };
    }
    
    public static Response<T> Fail<T>(string message) where T : class
    {
        return new Response<T>
        {
            IsSuccess = false,
            Message = message,
            StatusCode = StatusCode.BadRequest
        };
    }
}

public class Response<T> : Response where T : class
{
    public T Data { get; set; } = null!;
    
    public static Response<T> Fail(string message)
    {
        return new Response<T>
        {
            Data = null!,
            IsSuccess = false,
            Message = message,
            StatusCode = StatusCode.BadRequest
        };
    }
    
    public static Response<T> NotFound(string entityName)
    {
        return new Response<T>
        {
            Data = null!,
            IsSuccess = false,
            Message = $"{entityName} was not found",
            StatusCode = StatusCode.NotFound
        };
    }
}