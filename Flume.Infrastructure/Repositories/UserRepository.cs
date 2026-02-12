

using Flume.Application.Interfaces;
using Flume.Domain.Entities;
using Flume.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Flume.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            await _context.Set<User>().AddAsync(user, cancellationToken);
        }

        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<User>().ToListAsync(cancellationToken);
        }
    }
}
