using BackendPlayground.Api.Models;
using BackendPlayground.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendPlayground.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly CustomerService _customerService;

    public CustomersController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var customers = await _customerService.GetAllAsync();

        return Ok(customers);
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> Create(Customer customer)
    {
        var createdCustomer = await _customerService.CreateAsync(customer);

        return CreatedAtAction(
            nameof(GetAll),
            createdCustomer
        );
    }
}