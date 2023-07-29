namespace StockManagementSystem.Entities;

public class Size : BaseEntity
{
    public double SIUnit { get; set; }
    public string MeasurementId { get; set; } = null!;
    public Measurement Measurement { get; set; } = null!;
}
