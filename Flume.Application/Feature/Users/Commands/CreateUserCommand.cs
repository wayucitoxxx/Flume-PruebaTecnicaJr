using MediatR;

namespace Flume.Application.Features.Users.Commands.CreateUser
{
    public record CreateUserCommand(string Name, string Email) : IRequest<int>;
}
