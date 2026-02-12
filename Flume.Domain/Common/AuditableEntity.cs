using Flume.Domain.Interfaces;

namespace Flume.Domain.Common
{
    public class AuditableEntity : IAuditableEntity
    {
        public int CreatedBy { get; set; } = 1; //System
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
        public bool isActive { get; set; } = true;

    }
}
