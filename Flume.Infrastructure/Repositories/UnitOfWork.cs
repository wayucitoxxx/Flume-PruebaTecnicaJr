using Flume.Application.Interfaces;
using Flume.Infrastructure.Persistence;
using Flume.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IUserRepository _userRepository;
    private ITransactionRepository _transactionRepository;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IUserRepository User => _userRepository ??= new UserRepository(_context);

    public ITransactionRepository Transaction => _transactionRepository ??= new TransactionRepository(_context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
