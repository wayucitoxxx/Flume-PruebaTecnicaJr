
using Flume.Application.Dtos;
using MediatR;

namespace Flume.Application.Feature.Users.Queries
{
    public record GetAllUsersQueries() : IRequest<IEnumerable<UserDto>>
    {
    }
}
