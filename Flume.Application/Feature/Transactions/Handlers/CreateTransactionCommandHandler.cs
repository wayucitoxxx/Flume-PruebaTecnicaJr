
using Flume.Application.Dtos;
using Flume.Application.Feature.Transactions.Commands;
using Flume.Application.Interfaces;
using Flume.Domain.Entities;
using MediatR;

namespace Flume.Application.Feature.Transactions.Handlers
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, CreateTransactionDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateTransactionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateTransactionDto> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new Transaction
            {
                Type = request.Type,
                Amount = request.Amount,
                Description = request.Description,
                UserId = request.UserId
            };

            await _unitOfWork.Transaction.AddAsync(transaction, cancellationToken);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new CreateTransactionDto
            {
                Type = transaction.Type,
                Amount = transaction.Amount,
                Description = transaction.Description,
                UserId = transaction.UserId
            };
        }
    }
}
