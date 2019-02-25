using Newtonsoft.Json;

namespace AsyncSample
{
    public class GithubUser
    {
        public string Login { get; set; }
        [JsonProperty("avatar_url")]
        public string Avatar { get; set; }
        public int Followers { get; set; }

    }
}
