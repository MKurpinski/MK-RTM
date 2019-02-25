using MediatR;

namespace AsyncSample.Requests
{
    public class GetUserDetailsRequest: IRequest<GithubUserDetailsDto>
    {
        public string Username { get; }

        public GetUserDetailsRequest(string username)
        {
            Username = username;
        }
    }
}
