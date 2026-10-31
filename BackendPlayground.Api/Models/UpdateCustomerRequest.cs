using System.ComponentModel.DataAnnotations;

namespace BackendPlayground.Api.Models;

public class UpdateCustomerRequest
{
    [Required] [StringLength(100)] public string FisrtName { get; set; } = string.Empty;

    [Required] [StringLength(100)] public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(254)]
    public string Email { get; set; } = string.Empty;
}