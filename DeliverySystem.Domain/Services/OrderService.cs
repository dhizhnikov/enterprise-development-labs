/// <summary>
/// Сервис для управления заказами.
/// Обеспечивает логику работы с заказами, включая создание, обновление статуса и выборку.
/// </summary>
public class OrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Order GetOrderById(int id) => _orderRepository.GetById(id);
    // Другие методы...
}