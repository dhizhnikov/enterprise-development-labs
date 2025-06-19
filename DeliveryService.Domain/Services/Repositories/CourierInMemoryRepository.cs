/// <summary>
/// InMemory реализация репозитория курьеров
/// </summary>
public class CourierInMemoryRepository : ICourierRepository
{
    private readonly List<Courier> _couriers;
    private readonly List<Order> _orders;

    public CourierInMemoryRepository(List<Courier> couriers, List<Order> orders)
    {
        _couriers = couriers;
        _orders = orders;
    }

    public IEnumerable<Courier> GetTopCouriers()
    {
        var completedOrders = _orders.Where(o => o.Status == "Завершен" && o.CourierId.HasValue);

        var courierStats = completedOrders
            .GroupBy(o => o.CourierId.Value)
            .Select(g => new
            {
                CourierId = g.Key,
                OrderCount = g.Count()
            })
            .OrderByDescending(x => x.OrderCount)
            .ToList();

        if (!courierStats.Any()) return Enumerable.Empty<Courier>();

        var maxCount = courierStats.First().OrderCount;

        var topCourierIds = courierStats
            .Where(x => x.OrderCount == maxCount)
            .Select(x => x.CourierId);

        return _couriers.Where(c => topCourierIds.Contains(c.Id));
    }
}