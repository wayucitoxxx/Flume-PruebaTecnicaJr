using Flume.Application.Dtos;
using MediatR;

namespace Flume.Application.Features.Transactions.Queries.GetTransactionsByUserId
{
    public class GetTransactionsByUserIdQuery : IRequest<IEnumerable<TransactionDto>>
    {
        public int UserId { get; set; }

        public GetTransactionsByUserIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}