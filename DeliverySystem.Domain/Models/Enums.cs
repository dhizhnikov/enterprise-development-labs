/// <summary>
/// Содержит перечисления, используемые в системе доставки.
/// </summary>
public enum OrderStatus
{
    /// <summary> Новый заказ </summary>
    New,
    /// <summary> Заказ в процессе доставки </summary>
    InProgress,
    /// <summary> Заказ завершен </summary>
    Completed,
    /// <summary> Заказ отменен </summary>
    Cancelled
}

public enum ProductType
{
    /// <summary> Крупногабаритный товар </summary>
    Large,
    /// <summary> Мелкогабаритный товар </summary>
    Small
}