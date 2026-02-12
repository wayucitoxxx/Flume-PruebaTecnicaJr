
namespace Flume.Application.Dtos
{
    public class CreateTransactionDto
    {
        public string Type { get; set; } = string.Empty; // income || expense
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
    }
    public class TransactionDto
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty; // income || expense
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
    }
}
