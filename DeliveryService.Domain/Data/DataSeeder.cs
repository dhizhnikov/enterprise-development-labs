/// <summary>
/// Класс для заполнения начальными данными
/// </summary>
public static class DataSeeder
{
    /// <summary>
    /// Создает тестовые данные для приложения
    /// </summary>
    public static (List<Customer>, List<Vehicle>, List<Courier>, List<Order>) SeedData()
    {
  
        var customers = new List<Customer>
        {
            new Customer { Id = 1, FullName = "Иванов Иван Иванович", Address = "ул. Ленина, 10", PhoneNumber = "+79123456789" },
            new Customer { Id = 2, FullName = "Петров Петр Петрович", Address = "ул. Пушкина, 15", PhoneNumber = "+79234567890" },
            new Customer { Id = 3, FullName = "Сидорова Анна Владимировна", Address = "пр. Мира, 20", PhoneNumber = "+79345678901" }
        };


        var vehicles = new List<Vehicle>
        {
            new Vehicle { Id = 1, LicensePlate = "А123БВ777", Model = "Газель NEXT", CanCarryLargeCargo = true },
            new Vehicle { Id = 2, LicensePlate = "В456ТУ777", Model = "Renault Logan", CanCarryLargeCargo = false },
            new Vehicle { Id = 3, LicensePlate = "Е789КХ777", Model = "Ford Transit", CanCarryLargeCargo = true }
        };


        var couriers = new List<Courier>
        {
            new Courier { Id = 1, FullName = "Смирнов Алексей Дмитриевич", PhoneNumber = "+79456789012", VehicleId = 1 },
            new Courier { Id = 2, FullName = "Кузнецова Ольга Сергеевна", PhoneNumber = "+79567890123", VehicleId = 2 },
            new Courier { Id = 3, FullName = "Васильев Денис Игоревич", PhoneNumber = "+79678901234", VehicleId = 3 }
        };

  
        foreach (var courier in couriers)
        {
            courier.Vehicle = vehicles.First(v => v.Id == courier.VehicleId);
        }

  
        var orders = new List<Order>
        {
            new Order {
                Id = 1,
                OrderDate = new DateTime(2023, 10, 1),
                CustomerId = 1,
                Customer = customers[0],
                Status = "Завершен",
                ProductType = "Large",
                PlannedDeliveryDate = new DateTime(2023, 10, 2),
                PlannedDeliveryTime = new TimeSpan(14, 0, 0),
                CourierId = 1,
                Courier = couriers[0],
                ActualDeliveryDate = new DateTime(2023, 10, 2),
                ActualDeliveryTime = new TimeSpan(14, 30, 0)
            },
            new Order {
                Id = 2,
                OrderDate = new DateTime(2023, 10, 2),
                CustomerId = 2,
                Customer = customers[1],
                Status = "Завершен",
                ProductType = "Small",
                PlannedDeliveryDate = new DateTime(2023, 10, 3),
                PlannedDeliveryTime = new TimeSpan(12, 0, 0),
                CourierId = 2,
                Courier = couriers[1],
                ActualDeliveryDate = new DateTime(2023, 10, 3),
                ActualDeliveryTime = new TimeSpan(12, 10, 0)
            },
            new Order {
                Id = 3,
                OrderDate = new DateTime(2023, 10, 3),
                CustomerId = 3,
                Customer = customers[2],
                Status = "В процессе",
                ProductType = "Large",
                PlannedDeliveryDate = new DateTime(2023, 10, 5),
                PlannedDeliveryTime = new TimeSpan(16, 0, 0),
                CourierId = 3,
                Courier = couriers[2]
            },
            new Order {
                Id = 4,
                OrderDate = new DateTime(2023, 10, 4),
                CustomerId = 1,
                Customer = customers[0],
                Status = "Завершен",
                ProductType = "Small",
                PlannedDeliveryDate = new DateTime(2023, 10, 5),
                PlannedDeliveryTime = new TimeSpan(11, 0, 0),
                CourierId = 1,
                Courier = couriers[0],
                ActualDeliveryDate = new DateTime(2023, 10, 5),
                ActualDeliveryTime = new TimeSpan(11, 30, 0)
            },
            new Order {
                Id = 5,
                OrderDate = new DateTime(2023, 10, 5),
                CustomerId = 2,
                Customer = customers[1],
                Status = "Завершен",
                ProductType = "Large",
                PlannedDeliveryDate = new DateTime(2023, 10, 6),
                PlannedDeliveryTime = new TimeSpan(15, 0, 0),
                CourierId = 1,
                Courier = couriers[0],
                ActualDeliveryDate = new DateTime(2023, 10, 6),
                ActualDeliveryTime = new TimeSpan(15, 20, 0)
            }
        };

        return (customers, vehicles, couriers, orders);
    }
}