/// <summary>
/// Интерфейс репозитория для работы с заказами
/// </summary>
public interface IOrderRepository
{
    /// <summary>
    /// Получить заказ по номеру
    /// </summary>
    Order GetById(int id);

    /// <summary>
    /// Получить все завершенные заказы, отсортированные по дате заказа
    /// </summary>
    IEnumerable<Order> GetCompletedOrders();

    /// <summary>
    /// Получить заказы для доставки в указанный день с информацией о курьерах
    /// </summary>
    IEnumerable<Order> GetOrdersForDeliveryDate(DateTime date);

    /// <summary>
    /// Получить количество выполненных заказов по типам товаров
    /// </summary>
    Dictionary<string, int> GetCompletedOrdersCountByProductType();

    /// <summary>
    /// Получить заказы с опозданием доставки >= 15 минут
    /// </summary>
    IEnumerable<Order> GetDelayedOrders();
}