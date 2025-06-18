/// <summary>
/// Репозиторий для работы с покупателями в памяти.
/// Реализует интерфейс ICustomerRepository.
/// </summary>
public class CustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _customers = new();

    public Customer GetById(int id) => _customers.FirstOrDefault(c => c.Id == id);
    public IEnumerable<Customer> GetAll() => _customers;
    public void Add(Customer customer) => _customers.Add(customer);

    public void Clear()
    {
        throw new NotImplementedException();
    }
}