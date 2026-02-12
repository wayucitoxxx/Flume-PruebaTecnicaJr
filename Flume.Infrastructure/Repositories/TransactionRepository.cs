using Flume.Application.Interfaces;
using Flume.Domain.Entities;
using Flume.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Flume.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public readonly ApplicationDbContext _context;
        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Transaction transaction, CancellationToken cancellationToken)
        {
            await _context.Set<Transaction>().AddAsync(transaction, cancellationToken);
        }

        public async Task<IEnumerable<Transaction>> GetByUserIdAsync(int userId, CancellationToken cancellationToken)
        {
            return await _context.Set<Transaction>()
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.CreatedDate)
                .ToListAsync(cancellationToken);
        }
    }
}
