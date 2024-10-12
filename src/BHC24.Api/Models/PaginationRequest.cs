namespace BHC24.Api.Models;

public record PaginationRequest(int Page = 1, int PageSize = 20);