
namespace Flume.Application.Dtos
{
    public class UserBalanceDto
    {
        public int UserId { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal Balance { get; set; }
    }
}
