using Newtonsoft.Json;

namespace GithubClient.Models.CommitResponse
{
    public class Commit
    {
        public Author2 author { get; set; }
        public Committer committer { get; set; }
    
        [JsonProperty("message")]
        public string message { get; set; }
        public Tree tree { get; set; }
        public string url { get; set; }
        public int comment_count { get; set; }
        public Verification verification { get; set; }
    }
}