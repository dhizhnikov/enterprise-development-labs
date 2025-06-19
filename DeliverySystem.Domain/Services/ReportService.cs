using System;
using System.Collections.Generic;
using System.Linq;
using static ReportService;

/// <summary>
/// Сервис для генерации отчетов службы доставки.
/// </summary>
public class ReportService : IReportService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICourierRepository _courierRepository;

    /// <summary>
    /// Инициализирует новый экземпляр класса ReportService.
    /// </summary>
    public ReportService(IOrderRepository orderRepository, ICourierRepository courierRepository)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _courierRepository = courierRepository ?? throw new ArgumentNullException(nameof(courierRepository));
    }

    /// <summary>
    /// Получает детальную информацию о заказе по его идентификатору.
    /// </summary>
    public OrderResult GetOrderDetails(int orderId)
    {
        var order = _orderRepository.GetById(orderId);
        if (order == null)
            throw new KeyNotFoundException($"Заказ с ID {orderId} не найден");

        return new OrderResult(order);
    }

    /// <summary>
    /// Представляет результат запроса информации о заказе.
    /// </summary>
    public class OrderResult
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата оформления заказа
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Имя клиента, оформившего заказ
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Тип продукта в заказе
        /// </summary>
        public ProductType ProductType { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса OrderResult на основе данных заказа.
        /// </summary>
        public OrderResult(Order order)
        {
            Id = order.Id;
            OrderDate = order.OrderDate;
            CustomerName = order.Customer?.FullName ?? "Неизвестный клиент";
            ProductType = order.ProductType;
        }
    }

    /// <summary>
    /// Представляет результат запроса информации о курьере.
    /// </summary>
    public class CourierResult
    {
        /// <summary>
        /// Идентификатор курьера
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Полное имя курьера
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса CourierResult на основе данных курьера.
        /// </summary>
        public CourierResult(Courier courier)
        {
            Id = courier.Id;
            FullName = courier.FullName;
        }
    }

    /// <summary>
    /// Представляет график доставки, связывающий заказ с назначенным курьером.
    /// </summary>
    public class DeliverySchedule
    {
        /// <summary>
        /// Информация о заказе
        /// </summary>
        public OrderResult Order { get; set; }

        /// <summary>
        /// Информация о курьере
        /// </summary>
        public CourierResult Courier { get; set; }
    }

    /// <summary>
    /// Содержит статистику по типам продуктов.
    /// </summary>
    public class ProductTypeStats
    {
        /// <summary>
        /// Количество крупногабаритных товаров
        /// </summary>
        public int LargeItemsCount { get; set; }

        /// <summary>
        /// Количество мелкогабаритных товаров
        /// </summary>
        public int SmallItemsCount { get; set; }
    }

    /// <summary>
    /// Содержит статистику по курьерам.
    /// </summary>
    public class CourierStats
    {
        /// <summary>
        /// Информация о курьере
        /// </summary>
        public CourierResult Courier { get; set; }

        /// <summary>
        /// Количество завершенных заказов
        /// </summary>
        public int CompletedOrdersCount { get; set; }
    }
    /// <summary>
    /// Содержит информацию о задержках доставки.
    /// </summary>
    public class DeliveryDelayInfo
    {
        /// <summary>
        /// Информация о заказе
        /// </summary>
        public OrderResult Order { get; set; }

        /// <summary>
        /// Информация о курьере
        /// </summary>
        public CourierResult Courier { get; set; }

        /// <summary>
        /// Планируемое время доставки
        /// </summary>
        public DateTime PlannedDeliveryTime { get; set; }

        /// <summary>
        /// Фактическое время доставки
        /// </summary>
        public DateTime ActualDeliveryTime { get; set; }

        /// <summary>
        /// Продолжительность задержки
        /// </summary>
        public TimeSpan DelayDuration { get; set; }
    }
}