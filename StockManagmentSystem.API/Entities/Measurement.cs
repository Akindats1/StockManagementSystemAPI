using StockManagementSystem.Entity.Enums;

namespace StockManagementSystem.Entities;

public class Measurement : BaseEntity
{
    public ProductType ProductType { get; set; }
    public string UnitSizeType { get; set; } = null!;
    public ICollection<Size> Sizes { get; set; } = new HashSet<Size>();
}
