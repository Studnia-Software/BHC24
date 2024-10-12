namespace BHC24.Api.Models;

public class PaginationResponse<T>
{
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public IEnumerable<T> Data { get; set; }
}