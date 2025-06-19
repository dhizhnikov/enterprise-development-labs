/// <summary>
/// Модель заказа
/// </summary>
public class Order
{
    /// <summary>
    /// Уникальный номер заказа
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Дата создания заказа
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// Идентификатор покупателя
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Навигационное свойство для покупателя
    /// </summary>
    public Customer Customer { get; set; }

    /// <summary>
    /// Статус заказа (Новый, В процессе, Завершен и т.д.)
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Тип товара (Large - крупногабаритный, Small - мелкогабаритный)
    /// </summary>
    public string ProductType { get; set; }

    /// <summary>
    /// Планируемая дата доставки
    /// </summary>
    public DateTime PlannedDeliveryDate { get; set; }

    /// <summary>
    /// Планируемое время доставки
    /// </summary>
    public TimeSpan PlannedDeliveryTime { get; set; }

    /// <summary>
    /// Идентификатор курьера
    /// </summary>
    public int? CourierId { get; set; }

    /// <summary>
    /// Навигационное свойство для курьера
    /// </summary>
    public Courier Courier { get; set; }

    /// <summary>
    /// Фактическая дата доставки
    /// </summary>
    public DateTime? ActualDeliveryDate { get; set; }

    /// <summary>
    /// Фактическое время доставки
    /// </summary>
    public TimeSpan? ActualDeliveryTime { get; set; }
}