using System.Diagnostics.Metrics;

/// <summary>
/// Тесты для репозитория курьеров в памяти
/// </summary>
public class CourierInMemoryRepositoryTests
{
    private readonly List<Courier> _testCouriers;
    private readonly List<Order> _testOrders;
    private readonly CourierInMemoryRepository _repository;

    /// <summary>
    /// Инициализация тестовых данных
    /// </summary>
    public CourierInMemoryRepositoryTests()
    {
        var testData = DataSeeder.SeedData();
        _testCouriers = testData.Item3;
        _testOrders = testData.Item4;
        _repository = new CourierInMemoryRepository(_testCouriers, _testOrders);
    }

    /// <summary>
    /// Тест поиска курьера с максимальным количеством заказов
    /// </summary>
    [Fact]
    public void GetTopCouriers_ReturnsCourierWithMostOrders()
    {
        
        var result = _repository.GetTopCouriers().ToList();

     
        Assert.Single(result);
        Assert.Equal(1, result[0].Id);
    }

    /// <summary>
    /// Тест поиска курьеров при отсутствии завершенных заказов
    /// </summary>
    [Fact]
    public void GetTopCouriers_NoCompletedOrders_ReturnsEmpty()
    {
        
        var emptyOrders = new List<Order>();
        var repository = new CourierInMemoryRepository(_testCouriers, emptyOrders);

      
        var result = repository.GetTopCouriers();

       
        Assert.Empty(result);
    }
}