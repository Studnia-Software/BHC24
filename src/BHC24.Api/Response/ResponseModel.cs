using BHC24.Api.Response.Interfaces;

namespace BHC24.Api.Response;

public class ResponseModel : IResponseModel
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public int StatusCode { get; set; }
}