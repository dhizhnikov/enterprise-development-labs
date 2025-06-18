

/// <summary>
/// Класс для заполнения системы тестовыми данными.
/// Инициализирует репозитории начальными значениями для демонстрации работы сервисов.
/// </summary>
public static class DataSeeder
{
    /// <summary>
    /// Заполняет репозитории тестовыми данными:
    /// - Покупатели (Customers)
    /// - Транспортные средства (Vehicles)
    /// - Курьеры (Couriers)
    /// - Заказы (Orders)
    /// </summary>
    public static void Seed(
        ICustomerRepository customerRepository,
        IVehicleRepository vehicleRepository,
        ICourierRepository courierRepository,
        IOrderRepository orderRepository)
    {
        // Очистка существующих данных (для перезаполнения)
        customerRepository.Clear();
        vehicleRepository.Clear();
        courierRepository.Clear();
        orderRepository.Clear();

        // 1. Добавление транспортных средств
        var vehicle1 = new Vehicle { Id = 1, LicensePlate = "А123БВ", Model = "Газель NEXT", CanCarryLargeItems = true };
        var vehicle2 = new Vehicle { Id = 2, LicensePlate = "О456РТ", Model = "Lada Granta", CanCarryLargeItems = false };
        vehicleRepository.Add(vehicle1);
        vehicleRepository.Add(vehicle2);

        // 2. Добавление курьеров
        var courier1 = new Courier { Id = 1, FullName = "Иванов Петр Сергеевич", PhoneNumber = "+79001234567", Vehicle = vehicle1 };
        var courier2 = new Courier { Id = 2, FullName = "Сидорова Анна Владимировна", PhoneNumber = "+79007654321", Vehicle = vehicle2 };
        courierRepository.Add(courier1);
        courierRepository.Add(courier2);

        // 3. Добавление покупателей
        var customer1 = new Customer { Id = 1, FullName = "Козлов Дмитрий Иванович", Address = "ул. Ленина, д. 10, кв. 5", PhoneNumber = "+79151112233" };
        var customer2 = new Customer { Id = 2, FullName = "Морозова Екатерина Павловна", Address = "пр. Мира, д. 15, кв. 12", PhoneNumber = "+79152223344" };
        customerRepository.Add(customer1);
        customerRepository.Add(customer2);

        // 4. Добавление заказов
        var order1 = new Order
        {
            Id = 1,
            OrderDate = DateTime.Now.AddDays(-2),
            Customer = customer1,
            Status = OrderStatus.Completed,
            ProductType = ProductType.Large,
            PlannedDeliveryDate = DateTime.Now.AddDays(-1),
            ActualDeliveryDate = DateTime.Now.AddDays(-1).AddMinutes(10),
            Courier = courier1
        };

        var order2 = new Order
        {
            Id = 2,
            OrderDate = DateTime.Now.AddDays(-1),
            Customer = customer2,
            Status = OrderStatus.InProgress,
            ProductType = ProductType.Small,
            PlannedDeliveryDate = DateTime.Now.AddHours(2),
            ActualDeliveryDate = null,
            Courier = courier2
        };

        orderRepository.Add(order1);
        orderRepository.Add(order2);
    }
}

public interface IOrderRepository
{
    void Add(Order order1);
    void Clear();
    IEnumerable<object> GetAll();
    Order GetById(int id);
}

public interface ICourierRepository
{
    void Add(Courier courier2);
    void Clear();
}

public interface IVehicleRepository
{
    void Add(Vehicle vehicle2);
    void Clear();
}

public interface ICustomerRepository
{
    void Add(Customer customer2);
    void Clear();
}