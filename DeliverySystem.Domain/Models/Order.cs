using System.Diagnostics.Metrics;

/// <summary>
/// Представляет заказ в системе доставки.
/// Содержит информацию о номере заказа, дате, статусе, типе товара,
/// планируемом и фактическом времени доставки, а также ссылки на покупателя и курьера.
/// </summary>
public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public Customer Customer { get; set; }
    public OrderStatus Status { get; set; }
    public ProductType ProductType { get; set; }
    public DateTime PlannedDeliveryDate { get; set; }
    public DateTime? ActualDeliveryDate { get; set; }
    public Courier Courier { get; set; }
}