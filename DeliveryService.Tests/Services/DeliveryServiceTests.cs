/// <summary>
/// Тесты для сервиса доставки
/// </summary>
public class DeliveryServiceTests
{
    private readonly DeliveryService _service;
    private readonly List<Order> _testOrders;

    /// <summary>
    /// Инициализация тестового сервиса
    /// </summary>
    public DeliveryServiceTests()
    {
        var testData = DataSeeder.SeedData();
        _testOrders = testData.Item4;

        var orderRepository = new OrderInMemoryRepository(_testOrders);
        var courierRepository = new CourierInMemoryRepository(testData.Item3, _testOrders);
        _service = new DeliveryService(orderRepository, courierRepository);
    }

    /// <summary>
    /// Тест получения информации о заказе
    /// </summary>
    [Fact]
    public void GetOrderInfo_ExistingOrder_ReturnsOrder()
    {
        
        var existingOrderId = 2;

     
        var result = _service.GetOrderInfo(existingOrderId);

       
        Assert.NotNull(result);
        Assert.Equal(existingOrderId, result.Id);
    }

    /// <summary>
    /// Тест получения списка завершенных заказов
    /// </summary>
    [Fact]
    public void GetCompletedOrders_ReturnsCorrectCount()
    {
      
        var result = _service.GetCompletedOrders().ToList();

   
        Assert.Equal(4, result.Count);
    }

    /// <summary>
    /// Тест получения заказов на указанную дату
    /// </summary>
    [Fact]
    public void GetOrdersForDeliveryDate_ReturnsCorrectOrders()
    {
     
        var testDate = new DateTime(2023, 10, 5);

      
        var result = _service.GetOrdersForDeliveryDate(testDate).ToList();

        
        Assert.Equal(2, result.Count);
    }

    /// <summary>
    /// Тест получения статистики по типам товаров
    /// </summary>
    [Fact]
    public void GetCompletedOrdersStatistics_ReturnsCorrectData()
    {
      
        var result = _service.GetCompletedOrdersStatistics();

       
        Assert.Equal(2, result["Large"]);
        Assert.Equal(2, result["Small"]);
    }

    /// <summary>
    /// Тест получения лучших курьеров
    /// </summary>
    [Fact]
    public void GetTopCouriers_ReturnsCorrectCourier()
    {
     
        var result = _service.GetTopCouriers().ToList();

        
        Assert.Single(result);
        Assert.Equal(1, result[0].Id);
    }

    /// <summary>
    /// Тест получения заказов с опозданием
    /// </summary>
    [Fact]
    public void GetDelayedOrders_ReturnsDelayedOrders()
    {
        
        var result = _service.GetDelayedOrders().ToList();

        
        Assert.Equal(3, result.Count);
    }
}