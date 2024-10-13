using Newtonsoft.Json;

namespace GithubClient.Models;

public class PrResponseModel
{
    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("node_id")]
    public string NodeId { get; set; }

    [JsonProperty("html_url")]
    public string HtmlUrl { get; set; }

    [JsonProperty("diff_url")]
    public string DiffUrl { get; set; }

    [JsonProperty("patch_url")]
    public string PatchUrl { get; set; }

    [JsonProperty("issue_url")]
    public string IssueUrl { get; set; }

    [JsonProperty("number")]
    public int Number { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("locked")]
    public bool Locked { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("user")]
    public User User { get; set; }

    [JsonProperty("body")]
    public string Body { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonProperty("closed_at")]
    public DateTime? ClosedAt { get; set; }

    [JsonProperty("merged_at")]
    public DateTime? MergedAt { get; set; }
}