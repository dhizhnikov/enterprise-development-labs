/// <summary>
/// Репозиторий для работы с заказами в памяти.
/// Реализует интерфейс IOrderRepository.
/// </summary>
public class OrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();

    public Order GetById(int id) => _orders.FirstOrDefault(o => o.Id == id);
    public IEnumerable<Order> GetAll() => _orders;
    public void Add(Order order) => _orders.Add(order);

    public void Clear()
    {
        throw new NotImplementedException();
    }

    IEnumerable<object> IOrderRepository.GetAll()
    {
        return GetAll();
    }
    // Другие методы...
}