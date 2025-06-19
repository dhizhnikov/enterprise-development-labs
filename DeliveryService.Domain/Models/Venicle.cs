/// <summary>
/// Модель транспортного средства
/// </summary>
public class Vehicle
{
    /// <summary>
    /// Уникальный идентификатор транспортного средства
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Государственный номер
    /// </summary>
    public string LicensePlate { get; set; }

    /// <summary>
    /// Модель транспортного средства
    /// </summary>
    public string Model { get; set; }

    /// <summary>
    /// Может перевозить крупногабаритные грузы
    /// </summary>
    public bool CanCarryLargeCargo { get; set; }
}