namespace BHC24.Api.Response.Interfaces;

public interface IResponseDataModel<T> : IResponseModel
{
    public T Data { get; set; }
}