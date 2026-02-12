using Flume.Domain.Entities;

namespace Flume.Application.Interfaces
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction transaction, CancellationToken cancellationToken);

        Task<IEnumerable<Transaction>> GetByUserIdAsync(int userId, CancellationToken cancellationToken);
    }
}
