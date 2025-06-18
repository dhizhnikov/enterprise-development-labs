/// <summary>
/// Представляет покупателя (клиента) в системе доставки.
/// Содержит ФИО, адрес и контактный телефон.
/// </summary>
public class Customer
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}