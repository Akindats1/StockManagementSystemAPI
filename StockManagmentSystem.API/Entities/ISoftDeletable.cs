namespace StockManagementSystem.Entities;

public interface ISoftDeletable
{
    public bool IsDeleted { get; set; }
}
