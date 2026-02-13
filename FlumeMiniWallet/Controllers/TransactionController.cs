using Flume.Application.Dtos;
using Flume.Application.Feature.Transactions.Commands;
using Flume.Application.Features.Transactions.Queries.GetTransactionsByUserId;
using Flume.Application.Features.Transactions.Queries.GetUserBalance;
using Flume.Application.Features.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlumeMiniWallet.API.Controllers
{

    [ApiController]
    [Route("api/v1/Transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTransaction([FromBody] CreateTransactionDto createTransactionDto)
        {
            var command = new CreateTransactionCommand(
                createTransactionDto.Type,
                createTransactionDto.Amount,
                createTransactionDto.Description,
                createTransactionDto.UserId
                );
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("user/{Id}")]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetByUserId(int userId)
        {
            var query = new GetTransactionsByUserIdQuery(userId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{Id}/balance")]
        public async Task<ActionResult<UserBalanceDto>> GetBalance(int id)
        {
            var query = new GetUserBalanceQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
