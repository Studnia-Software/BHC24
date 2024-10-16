using Newtonsoft.Json;

namespace GithubClient.Models;

public class IssuesResponseModel
{
    [JsonProperty("url")]
    public string url { get; set; }
    public string repository_url { get; set; }
    public string labels_url { get; set; }
    public string comments_url { get; set; }
    public string events_url { get; set; }
    public string html_url { get; set; }
    public string node_id { get; set; }
    public int number { get; set; }
    public string title { get; set; }
    public User user { get; set; }
    public List<Label> labels { get; set; }
    public string state { get; set; }
    public bool locked { get; set; }
    public object assignee { get; set; }
    public List<object> assignees { get; set; }
    public Milestone milestone { get; set; }
    public int comments { get; set; }
    public object created_at { get; set; }
    public object updated_at { get; set; }
    public object closed_at { get; set; }
    public string author_association { get; set; }
    public object active_lock_reason { get; set; }
    
    [JsonProperty("body")]
    public string body { get; set; }
    public object closed_by { get; set; }
    public string timeline_url { get; set; }
    public object performed_via_github_app { get; set; }
    public object state_reason { get; set; }
}