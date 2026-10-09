using BackendPlayground.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendPlayground.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetCustomer()
    {
        var customers = new List<Customer>
        {
            new()
            {
                Id = 1,
                FirstName = "Kamyar",
                LastName = "Ganjian",
                Email = "kamyarganjian@gmail.com"
            }
        };
        return Ok(customers);
    }
}

