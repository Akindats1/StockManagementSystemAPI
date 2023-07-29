using StockManagementSystem.Entity.Enums;

namespace StockManagementSystem.Entities;

public class Product : BaseEntity
{
    public string CategoryId { get; set; } = null!;
    public Category Category { get; set; } = null!;
    public string SizeId { get; set; } = null!;
    public Size Size { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string? Description { get; set; }
    public decimal UnitCostPrice { get; set; }
    public decimal UnitPrice { get; set; }
    public int TotalUnit { get; set; }
    public int? TotalPack { get; set; }
    public ProductClass ProductClass { get; set; }
}