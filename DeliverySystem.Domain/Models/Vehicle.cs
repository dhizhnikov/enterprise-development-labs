/// <summary>
/// Представляет транспортное средство курьера.
/// Содержит гос. номер, модель и информацию о возможности перевозки крупногабаритных грузов.
/// </summary>
public class Vehicle
{
    public int Id { get; set; }
    public string LicensePlate { get; set; }
    public string Model { get; set; }
    public bool CanCarryLargeItems { get; set; }
}