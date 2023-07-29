using MassTransit;

namespace StockManagementSystem.Entities;

public abstract class BaseEntity : IAuditBase, ISoftDeletable
{
    public string Id { get; set; } = NewId.Next().ToSequentialGuid().ToString();
    public string CreatedBy { get; set; } = null!;
    public string? ModifiedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public bool IsDeleted { get; set; }
}
