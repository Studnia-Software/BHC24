namespace BHC24.Api.Response.Interfaces;

public interface IResponseModel
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public int StatusCode { get; set; }
}