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
    [ProducesResponseType(typeof(List<Customer>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Customer>>> GetAll()
    {
        var customers = await _customerService.GetAllAsync();

        return Ok(customers);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Customer>> GetById(int id)
    {
        var customer = await _customerService.GetByIdAsync(id);

        if (customer is null) return NotFound();

        return Ok(customer);
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

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdCustomer.Id },
            createdCustomer);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        int id,
        UpdateCustomerRequest request)
    {
        var updated = await _customerService.UpdateAsync(id, request);

        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _customerService.DeleteAsync(id);

        if (!deleted) return NotFound();
        return NoContent();
    }
}