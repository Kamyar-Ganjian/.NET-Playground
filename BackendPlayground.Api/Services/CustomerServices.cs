
using BackendPlayground.Api.Data;
using BackendPlayground.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendPlayground.Api.Services;

public class CustomerService
{
    private readonly AppDbContext _dbContext;

    public CustomerService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await _dbContext.Customers.ToListAsync();
    }

    public async Task<Customer> CreateAsync(Customer customer)
    {
        _dbContext.Customers.Add(customer);

        await _dbContext.SaveChangesAsync();

        return customer;
    }
}
