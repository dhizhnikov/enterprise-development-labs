/// <summary>
/// Модель курьера
/// </summary>
public class Courier
{
    /// <summary>
    /// Уникальный идентификатор курьера
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ФИО курьера
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Номер телефона курьера
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Идентификатор транспортного средства
    /// </summary>
    public int VehicleId { get; set; }

    /// <summary>
    /// Навигационное свойство для транспортного средства
    /// </summary>
    public Vehicle Vehicle { get; set; }
}