using Flume.Application.Dtos;
using MediatR;

namespace Flume.Application.Features.Transactions.Queries.GetUserBalance
{
    public class GetUserBalanceQuery : IRequest<UserBalanceDto>
    {
        public int UserId { get; set; }

        public GetUserBalanceQuery(int userId)
        {
            UserId = userId;
        }
    }
}