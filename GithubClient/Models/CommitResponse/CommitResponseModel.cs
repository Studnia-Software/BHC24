namespace GithubClient.Models.CommitResponse;

public class CommitResponseModel
{
    public string sha { get; set; }
    public string node_id { get; set; }
    public Commit commit { get; set; }
    public string url { get; set; }
    public string html_url { get; set; }
    public string comments_url { get; set; }
    public Author2 author { get; set; }
    public Committer2 committer { get; set; }
    public List<Parent> parents { get; set; }
}