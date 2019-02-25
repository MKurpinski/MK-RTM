using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RestEase;

namespace AsyncSample
{
    [Header("User-Agent", "asyncSample")]
    [AllowAnyStatusCode]
    public interface IGithubApi
    {
        [Get("/users/{username}/repos")]
        Task<Response<IEnumerable<GithubRepository>>> GetReposAsync([Path] string username, CancellationToken cancellationToken);
        [Get("/users/{username}")]
        Task<Response<GithubUser>> GetUserAsync([Path] string username, CancellationToken cancellationToken);
    }
}
