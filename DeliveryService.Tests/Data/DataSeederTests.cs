/// <summary>
/// Тесты для генератора тестовых данных
/// </summary>
public class DataSeederTests
{
    /// <summary>
    /// Тест генерации тестовых данных
    /// </summary>
    [Fact]
    public void SeedData_GeneratesValidTestData()
    {

        var (customers, vehicles, couriers, orders) = DataSeeder.SeedData();


        Assert.Equal(3, customers.Count);
        Assert.Equal(3, vehicles.Count);
        Assert.Equal(3, couriers.Count);
        Assert.Equal(5, orders.Count);


        Assert.All(couriers, c =>
        {
            Assert.NotNull(c.Vehicle);
            Assert.Equal(c.VehicleId, c.Vehicle.Id);
        });

        Assert.All(orders.Where(o => o.CourierId.HasValue), o =>
        {
            Assert.NotNull(o.Courier);
            Assert.Equal(o.CourierId, o.Courier.Id);
        });

        Assert.All(orders, o =>
        {
            Assert.NotNull(o.Customer);
            Assert.Equal(o.CustomerId, o.Customer.Id);
        });
    }
}