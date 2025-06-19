/// <summary>
/// Сервис для работы с доставками
/// </summary>
public class DeliveryService : IDeliveryService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICourierRepository _courierRepository;

    public DeliveryService(IOrderRepository orderRepository, ICourierRepository courierRepository)
    {
        _orderRepository = orderRepository;
        _courierRepository = courierRepository;
    }

    public Order GetOrderInfo(int orderId)
    {
        return _orderRepository.GetById(orderId);
    }

    public IEnumerable<Order> GetCompletedOrders()
    {
        return _orderRepository.GetCompletedOrders();
    }

    public IEnumerable<Order> GetOrdersForDeliveryDate(DateTime date)
    {
        return _orderRepository.GetOrdersForDeliveryDate(date);
    }

    public Dictionary<string, int> GetCompletedOrdersStatistics()
    {
        return _orderRepository.GetCompletedOrdersCountByProductType();
    }

    public IEnumerable<Courier> GetTopCouriers()
    {
        return _courierRepository.GetTopCouriers();
    }

    public IEnumerable<Order> GetDelayedOrders()
    {
        return _orderRepository.GetDelayedOrders();
    }
}