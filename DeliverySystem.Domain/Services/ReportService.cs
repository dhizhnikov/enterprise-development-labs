using System;
using System.Collections.Generic;
using System.Linq;
using static ReportService;

/// <summary>
/// Сервис для генерации отчетов службы доставки
/// </summary>
public class ReportService : IReportService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICourierRepository _courierRepository;

    /// <summary>
    /// Инициализирует новый экземпляр ReportService
    /// </summary>
    public ReportService(IOrderRepository orderRepository, ICourierRepository courierRepository)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _courierRepository = courierRepository ?? throw new ArgumentNullException(nameof(courierRepository));
    }

    /// <summary>
    /// Получить информацию о заказе по номеру (Запрос 1)
    /// </summary>
    public OrderResult GetOrderDetails(int orderId)
    {
        var order = _orderRepository.GetById(orderId);
        if (order == null)
            throw new KeyNotFoundException($"Заказ с ID {orderId} не найден");

        return new OrderResult(order);
    }

    /// <summary>
    /// Модели результатов для отчетов
    /// </summary>
    public class OrderResult
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public ProductType ProductType { get; set; }

        public OrderResult(Order order)
        {
            Id = order.Id;
            OrderDate = order.OrderDate;
            CustomerName = order.Customer?.FullName ?? "Неизвестный клиент";
            ProductType = order.ProductType;
        }
    }

    public class CourierResult
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public CourierResult(Courier courier)
        {
            Id = courier.Id;
            FullName = courier.FullName;
        }
    }

    public class DeliverySchedule
    {
        public OrderResult Order { get; set; }
        public CourierResult Courier { get; set; }
    }

    public class ProductTypeStats
    {
        public int LargeItemsCount { get; set; }
        public int SmallItemsCount { get; set; }
    }

    public class CourierStats
    {
        public CourierResult Courier { get; set; }
        public int CompletedOrdersCount { get; set; }
    }

    public class DeliveryDelayInfo
    {
        public OrderResult Order { get; set; }
        public CourierResult Courier { get; set; }
        public DateTime PlannedDeliveryTime { get; set; }
        public DateTime ActualDeliveryTime { get; set; }
        public TimeSpan DelayDuration { get; set; }
    }
}

public interface IReportService
{
}