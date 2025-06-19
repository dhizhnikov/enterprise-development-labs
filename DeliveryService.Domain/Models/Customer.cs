/// <summary>
/// Модель покупателя
/// </summary>
public class Customer
{
    /// <summary>
    /// Уникальный идентификатор покупателя
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ФИО покупателя
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Адрес покупателя
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Номер телефона покупателя
    /// </summary>
    public string PhoneNumber { get; set; }
}