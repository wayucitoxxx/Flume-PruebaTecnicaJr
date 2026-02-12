
using Flume.Application.Dtos;
using Flume.Application.Feature.Users.Queries;
using Flume.Application.Interfaces;
using MediatR;

namespace Flume.Application.Feature.Users.Handlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueries, IEnumerable<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllUsersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }   
        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQueries request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.User.GetAllAsync(cancellationToken);
            return users
                .Where(u => u.isActive)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email
                });
        }
    }
}
