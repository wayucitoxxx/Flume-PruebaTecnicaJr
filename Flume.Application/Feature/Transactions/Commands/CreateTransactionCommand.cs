
using Flume.Application.Dtos;
using MediatR;

namespace Flume.Application.Feature.Transactions.Commands
{
    public record CreateTransactionCommand(
        string Type,
        decimal Amount,
        string? Description,
        int UserId
        ) : IRequest<CreateTransactionDto>
    {
    }
}
