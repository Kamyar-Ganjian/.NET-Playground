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
    [ProducesResponseType(typeof(Customer), StatusCodes.Status201Created)]
    public async Task<ActionResult<Customer>> Create(
        CreateCustomerRequest request)
    {
        var customer = new Customer
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email
        };

        var createdCustomer = await _customerService.CreateAsync(customer);

        return StatusCode(StatusCodes.Status201Created, createdCustomer);
    }
}