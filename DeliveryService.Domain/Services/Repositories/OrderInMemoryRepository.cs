/// <summary>
/// InMemory реализация репозитория заказов
/// </summary>
public class OrderInMemoryRepository : IOrderRepository
{
    private readonly List<Order> _orders;

    public OrderInMemoryRepository(List<Order> orders)
    {
        _orders = orders;
    }

    public Order GetById(int id)
    {
        return _orders.FirstOrDefault(o => o.Id == id);
    }

    public IEnumerable<Order> GetCompletedOrders()
    {
        return _orders
            .Where(o => o.Status == "Завершен")
            .OrderBy(o => o.OrderDate);
    }

    public IEnumerable<Order> GetOrdersForDeliveryDate(DateTime date)
    {
        return _orders
            .Where(o => o.PlannedDeliveryDate.Date == date.Date && o.Courier != null)
            .OrderBy(o => o.PlannedDeliveryTime);
    }

    public Dictionary<string, int> GetCompletedOrdersCountByProductType()
    {
        return _orders
            .Where(o => o.Status == "Завершен")
            .GroupBy(o => o.ProductType)
            .ToDictionary(g => g.Key, g => g.Count());
    }

    public IEnumerable<Order> GetDelayedOrders()
    {
        return _orders
            .Where(o => o.Status == "Завершен" &&
                       o.ActualDeliveryDate.HasValue &&
                       o.ActualDeliveryTime.HasValue &&
                       (o.ActualDeliveryDate.Value > o.PlannedDeliveryDate ||
                       (o.ActualDeliveryDate.Value == o.PlannedDeliveryDate &&
                        o.ActualDeliveryTime.Value >= o.PlannedDeliveryTime.Add(TimeSpan.FromMinutes(15)))))
            .OrderByDescending(o => (o.ActualDeliveryDate.Value - o.PlannedDeliveryDate) +
                                   (o.ActualDeliveryTime.Value - o.PlannedDeliveryTime));
    }
}