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
    public ActionResult GetAll()
    {
        return Ok(_customerService.GetAll());
    }
}