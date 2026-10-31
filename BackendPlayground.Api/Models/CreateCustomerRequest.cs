using System.ComponentModel.DataAnnotations;

namespace BackendPlayground.Api.Models;

public class CreateCustomerRequest
{
    [Required] [StringLength(100)] public string FirstName { get; set; } = string.Empty;

    [Required] [StringLength(100)] public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(254)]
    public string Email { get; set; } = string.Empty;
}