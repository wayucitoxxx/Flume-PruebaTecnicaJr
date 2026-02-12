
namespace Flume.Domain.Interfaces
{
    public interface IAuditableEntity
    {
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int? LastModifiedBy { get; set; }
        DateTime LastModifiedDate { get; set; }
        bool isActive { get; set; }
    }
}
