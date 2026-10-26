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

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await _dbContext.Customers
            .FirstOrDefaultAsync(customer => customer.Id == id);
    }

    public async Task<Customer> CreateAsync(Customer customer)
    {
        _dbContext.Customers.Add(customer);

        await _dbContext.SaveChangesAsync();

        return customer;
    }

    public async Task<bool> UpdateAsync(int id, UpdateCustomerRequest request)
    {
        var customer = await _dbContext.Customers.FindAsync(id);

        if (customer is null) return false;

        customer.FirstName = request.FisrtName;
        customer.LastName = request.LastName;
        customer.Email = request.Email;

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var customer = await _dbContext.Customers.FindAsync(id);

        if (customer is null) return false;

        _dbContext.Customers.Remove(customer);

        await _dbContext.SaveChangesAsync();

        return true;
    }
}