using BackendPlayground.Api.Models;

namespace BackendPlayground.Api.Services;

public class CustomerService
{
    private readonly List<Customer> _Customers =
    [
        new Customer
        {
            Id = 1,
            FirstName = "Kamyar",
            LastName = "Ganjian",
            Email = "kamyar@example.com"
        },
        new Customer
        {
            Id = 2,
            FirstName = "Sara",
            LastName = "Ahmadi",
            Email = "sara@example.com"
        }
    ];

    public IReadOnlyList<Customer> GetAll()
    {
        return _Customers.AsReadOnly();
    }
}

