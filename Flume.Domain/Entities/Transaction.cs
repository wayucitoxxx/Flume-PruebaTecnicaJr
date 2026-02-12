using Flume.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flume.Domain.Entities
{
    public class Transaction : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Type { get; set; } = null!; // income || expense
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        //public decimal Balance { get; set; } = 0;
        public int UserId { get; set; }
        //Navigation Property
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;
    }
}
