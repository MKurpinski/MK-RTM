using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AsyncSample.Requests;
using MediatR;
using RestEase;

namespace AsyncSample.RequestHandlers
{
    public class GetUserDetailsHandler : IRequestHandler<GetUserDetailsRequest, GithubUserDetailsDto>
    {
        private readonly IGithubApi _api;
        private const string GITHUB_API_ADDRESS = "https://api.github.com";

        public GetUserDetailsHandler()
        {
            _api = RestClient.For<IGithubApi>(GITHUB_API_ADDRESS);
        }

        public async Task<GithubUserDetailsDto> Handle(GetUserDetailsRequest request, CancellationToken cancellationToken)
        {
            var reposTask = _api.GetReposAsync(request.Username, cancellationToken);
            var userInfoTask = _api.GetUserAsync(request.Username, cancellationToken);

            var reposResponse = await reposTask;
            var userInfoResponse = await userInfoTask;

            if (!AreAllMessagesSuccessful(reposResponse.ResponseMessage, userInfoResponse.ResponseMessage))
            {
                return null;
            }

            return new GithubUserDetailsDto(reposResponse.GetContent(), userInfoResponse.GetContent());
        }

        private bool AreAllMessagesSuccessful(params HttpResponseMessage[] responses)
        {
            return responses.All(x => x.IsSuccessStatusCode);
        }
    }
}
