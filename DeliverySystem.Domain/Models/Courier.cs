/// <summary>
/// Представляет курьера, осуществляющего доставку заказов.
/// Содержит ФИО, контактный телефон и ссылку на транспортное средство.
/// </summary>
public class Courier
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public Vehicle Vehicle { get; set; }
}