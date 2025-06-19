/// <summary>
/// Тесты для репозитория заказов в памяти
/// </summary>
public class OrderInMemoryRepositoryTests
{
    private readonly List<Order> _testOrders;
    private readonly OrderInMemoryRepository _repository;

    /// <summary>
    /// Инициализация тестовых данных
    /// </summary>
    public OrderInMemoryRepositoryTests()
    {
        var testData = DataSeeder.SeedData();
        _testOrders = testData.Item4;
        _repository = new OrderInMemoryRepository(_testOrders);
    }

    /// <summary>
    /// Тест получения заказа по существующему ID
    /// </summary>
    [Fact]
    public void GetById_ExistingId_ReturnsOrder()
    {
      
        var existingOrderId = 1;

       
        var result = _repository.GetById(existingOrderId);

 
        Assert.NotNull(result);
        Assert.Equal(existingOrderId, result.Id);
    }

    /// <summary>
    /// Тест получения заказа по несуществующему ID
    /// </summary>
    [Fact]
    public void GetById_NonExistingId_ReturnsNull()
    {
       
        var nonExistingOrderId = 999;

 
        var result = _repository.GetById(nonExistingOrderId);

      
        Assert.Null(result);
    }

    /// <summary>
    /// Тест получения только завершенных заказов
    /// </summary>
    [Fact]
    public void GetCompletedOrders_ReturnsOnlyCompletedOrders()
    {
        
        var result = _repository.GetCompletedOrders().ToList();

      
        Assert.NotEmpty(result);
        Assert.All(result, o => Assert.Equal("Завершен", o.Status));
    }

    /// <summary>
    /// Тест сортировки завершенных заказов по дате
    /// </summary>
    [Fact]
    public void GetCompletedOrders_ReturnsOrdersOrderedByDate()
    {
       
        var result = _repository.GetCompletedOrders().ToList();

        
        for (int i = 0; i < result.Count - 1; i++)
        {
            Assert.True(result[i].OrderDate <= result[i + 1].OrderDate);
        }
    }

    /// <summary>
    /// Тест получения заказов на конкретную дату доставки
    /// </summary>
    [Fact]
    public void GetOrdersForDeliveryDate_ReturnsOrdersForSpecifiedDate()
    {
       
        var testDate = new DateTime(2023, 10, 5);

      
        var result = _repository.GetOrdersForDeliveryDate(testDate).ToList();

       
        Assert.NotEmpty(result);
        Assert.All(result, o => Assert.Equal(testDate.Date, o.PlannedDeliveryDate.Date));
    }

    /// <summary>
    /// Тест статистики по типам товаров
    /// </summary>
    [Fact]
    public void GetCompletedOrdersCountByProductType_ReturnsCorrectStatistics()
    {
        
        var result = _repository.GetCompletedOrdersCountByProductType();

      
        Assert.Equal(2, result["Large"]);
        Assert.Equal(2, result["Small"]);
    }

    /// <summary>
    /// Тест получения заказов с опозданием доставки
    /// </summary>
    [Fact]
    public void GetDelayedOrders_ReturnsOnlyDelayedOrders()
    {
       
        var result = _repository.GetDelayedOrders().ToList();

       
        Assert.NotEmpty(result);
        Assert.All(result, o =>
        {
            var delay = (o.ActualDeliveryDate!.Value - o.PlannedDeliveryDate) +
                        (o.ActualDeliveryTime!.Value - o.PlannedDeliveryTime);
            Assert.True(delay >= TimeSpan.FromMinutes(15));
        });
    }
}