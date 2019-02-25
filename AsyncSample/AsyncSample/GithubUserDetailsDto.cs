using System.Collections.Generic;
using System.Linq;

namespace AsyncSample
{
    public class GithubUserDetailsDto
    {
        public List<GithubRepository> Repos { get; }
        public GithubUser UserDetails { get; }

        public GithubUserDetailsDto(IEnumerable<GithubRepository> repos, GithubUser userDetails)
        {
            Repos = repos.ToList();
            UserDetails = userDetails;
        }
    }
}
