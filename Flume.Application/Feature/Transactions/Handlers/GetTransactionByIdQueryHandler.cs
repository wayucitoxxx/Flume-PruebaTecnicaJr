// Flume.Application/Features/Transactions/Queries/GetTransactionsByUserId/GetTransactionsByUserIdQueryHandler.cs
using Flume.Application.Dtos;
using Flume.Application.Interfaces;
using MediatR;

namespace Flume.Application.Features.Transactions.Queries.GetTransactionsByUserId
{
    public class GetTransactionsByUserIdQueryHandler : IRequestHandler<GetTransactionsByUserIdQuery, IEnumerable<TransactionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTransactionsByUserIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TransactionDto>> Handle(GetTransactionsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _unitOfWork.Transaction.GetByUserIdAsync(request.UserId, cancellationToken);

            return transactions.Select(t => new TransactionDto
            {
                Id = t.Id,
                Type = t.Type,
                Amount = t.Amount,
                Description = t.Description,
                UserId = t.UserId
            });
        }
    }
}