/// <summary>
/// Интерфейс репозитория для работы с курьерами
/// </summary>
public interface ICourierRepository
{
    /// <summary>
    /// Получить курьеров с максимальным количеством выполненных заказов
    /// </summary>
    IEnumerable<Courier> GetTopCouriers();
}