using Azure.Core;
using Flume.Application.Dtos;
using Flume.Application.Features.Users.Commands.CreateUser;
using Flume.Application.Interfaces;
using Flume.Domain.Entities;
using MediatR;
using System.Threading;

namespace Flume.Application.Features.Users.Handlers
{
    public class CreateUserCommandHandler
        : IRequestHandler<CreateUserCommand, CreateUserDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<CreateUserDto> Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var existing = await _unitOfWork.User
                .GetByEmailAsync(request.Email, cancellationToken);

            if (existing is not null)
                throw new Exception("El Email ya fue registrado");

            var user = new User
            {
                Name = request.Name,
                Email = request.Email
            };

            await _unitOfWork.User.AddAsync(user, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new CreateUserDto
            {
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
