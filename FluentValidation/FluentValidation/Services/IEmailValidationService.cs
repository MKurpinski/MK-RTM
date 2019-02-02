using System.Threading;
using System.Threading.Tasks;

namespace FluentValidationExample.Services
{
    public interface IEmailValidationService
    {
        Task<bool> IsUnique(string email, CancellationToken cancelationToken);
    }

    public class EmailValidationService : IEmailValidationService
    {
        public Task<bool> IsUnique(string email, CancellationToken cancelationToken)
        {
            var isUnique = email.StartsWith("unique");
            return Task.FromResult(isUnique);
        }
    }
}
