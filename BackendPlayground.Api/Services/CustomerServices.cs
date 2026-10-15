using BackendPlayground.Api.Models;

namespace BackendPlayground.Api.Services;

public class CustomerService
{
    private readonly List<Customer> _customers =
    [
        new()
        {
            Id = 1,
            FirstName = "Kamyar",
            LastName = "Ganjian",
            Email = "kamyar@example.com"
        },
        new()
        {
            Id = 2,
            FirstName = "Sara",
            LastName = "Ahmadi",
            Email = "sara@example.com"
        }
    ];

    public IReadOnlyList<Customer> GetAll()
    {
        return _customers.AsReadOnly();
    }

    public Customer Create(Customer customer)
    {
        customer.Id = _customers.Count == 0
            ? 1
            : _customers.Max(c => c.Id) + 1;

        _customers.Add(customer);

        return customer;
    }
}