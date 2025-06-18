/// <summary>
/// Репозиторий для работы с курьерами в памяти.
/// Реализует интерфейс ICourierRepository.
/// </summary>
public class CourierRepository : ICourierRepository
{
    private readonly List<Courier> _couriers = new();

    public Courier GetById(int id) => _couriers.FirstOrDefault(c => c.Id == id);
    public IEnumerable<Courier> GetAll() => _couriers;
    public void Add(Courier courier) => _couriers.Add(courier);

    public void Clear()
    {
        throw new NotImplementedException();
    }
}