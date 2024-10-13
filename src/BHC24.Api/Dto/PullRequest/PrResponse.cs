namespace BHC24.Api.Dto.PullRequest;

public class PrResponse
{
    public string Url { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? ClosedAt { get; set; }
    public DateTime? MergedAt { get; set; }
}