
namespace Flume.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        ITransactionRepository Transaction { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
