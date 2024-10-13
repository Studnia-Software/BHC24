namespace BHC24.Api.Dto.Issues;

public class IssuesResponseDto
{
    public string Url { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public object? ClosedAt { get; set; }
    public object? CreatedAt { get; set; }
    public object? UpdatedAt { get; set; }
}