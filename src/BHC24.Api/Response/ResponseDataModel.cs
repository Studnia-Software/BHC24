using BHC24.Api.Response.Interfaces;

namespace KalkulatorWILKS.Api.Response;

public class ResponseDataModel<T> : ResponseModel, IResponseDataModel<T> where T : class
{
    public T Data { get; set; } = null!;
}