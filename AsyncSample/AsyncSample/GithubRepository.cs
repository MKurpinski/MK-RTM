using Newtonsoft.Json;

namespace AsyncSample
{
    public class GithubRepository
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonProperty("url")]
        public string Link { get; set; }
        [JsonProperty("stargazers_count")]
        public int Stars { get; set; }
    }
}
