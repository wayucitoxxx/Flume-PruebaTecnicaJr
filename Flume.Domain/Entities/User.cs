
using Flume.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Flume.Domain.Entities
{
    public class User : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        //Navigation Property
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    }
}
