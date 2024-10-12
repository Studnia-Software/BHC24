using Newtonsoft.Json;

namespace GithubClient.Models;

public class IssuesResponseModel
{
    public string NodeId { get; set; }
    public string Url { get; set; }
    public string RepositoryUrl { get; set; }
    public string LabelsUrl { get; set; }
    public string CommentsUrl { get; set; }
    public string EventsUrl { get; set; }
    public string HtmlUrl { get; set; }
    public int Number { get; set; }
    public string State { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public User User { get; set; }
    public List<Label> Labels { get; set; }
    public User Assignee { get; set; }
    public List<User> Assignees { get; set; }
    public Milestone Milestone { get; set; }
    public bool Locked { get; set; }
    public string ActiveLockReason { get; set; }
    public int Comments { get; set; }
    public PullRequest PullRequest { get; set; }
    
    [JsonProperty("created_at")]
    public DateTime? ClosedAt { get; set; }
    
    [JsonProperty("closed_at")]
    public DateTime CreatedAt { get; set; }
    
    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }
    public User ClosedBy { get; set; }
    public string AuthorAssociation { get; set; }
    public string StateReason { get; set; }
}