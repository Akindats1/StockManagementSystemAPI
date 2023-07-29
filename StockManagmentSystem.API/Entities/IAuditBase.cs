namespace StockManagementSystem.Entities;

public interface IAuditBase
{
    public string CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
}