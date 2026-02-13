// Flume.Application/Features/Transactions/Queries/GetUserBalance/GetUserBalanceQueryHandler.cs
using Flume.Application.Dtos;
using Flume.Application.Interfaces;
using MediatR;

namespace Flume.Application.Features.Transactions.Queries.GetUserBalance
{
    public class GetUserBalanceQueryHandler : IRequestHandler<GetUserBalanceQuery, UserBalanceDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserBalanceQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserBalanceDto> Handle(GetUserBalanceQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _unitOfWork.Transaction.GetByUserIdAsync(request.UserId, cancellationToken);

            var totalIncome = transactions
                .Where(t => t.Type.ToLower() == "income")
                .Sum(t => t.Amount);

            var totalExpense = transactions
                .Where(t => t.Type.ToLower() == "expense")
                .Sum(t => t.Amount);

            return new UserBalanceDto
            {
                UserId = request.UserId,
                TotalIncome = totalIncome,
                TotalExpense = totalExpense,
                Balance = totalIncome - totalExpense
            };
        }
    }
}