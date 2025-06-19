/// <summary>
/// Интерфейс сервиса доставки
/// </summary>
public interface IDeliveryService
{
    /// <summary>
    /// Получить информацию о заказе по номеру
    /// </summary>
    Order GetOrderInfo(int orderId);

    /// <summary>
    /// Получить список завершенных заказов
    /// </summary>
    IEnumerable<Order> GetCompletedOrders();

    /// <summary>
    /// Получить заказы и курьеров на указанную дату доставки
    /// </summary>
    IEnumerable<Order> GetOrdersForDeliveryDate(DateTime date);

    /// <summary>
    /// Получить статистику по выполненным заказам по типам товаров
    /// </summary>
    Dictionary<string, int> GetCompletedOrdersStatistics();

    /// <summary>
    /// Получить топ курьеров по количеству выполненных заказов
    /// </summary>
    IEnumerable<Courier> GetTopCouriers();

    /// <summary>
    /// Получить заказы с опозданием доставки
    /// </summary>
    IEnumerable<Order> GetDelayedOrders();
}