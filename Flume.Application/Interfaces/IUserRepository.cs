
using Flume.Domain.Entities;

namespace Flume.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(User user, CancellationToken cancellationToken);
    }
}
