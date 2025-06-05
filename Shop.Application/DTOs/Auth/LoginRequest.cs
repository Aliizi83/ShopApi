using System.ComponentModel.DataAnnotations;

namespace Shop.Application.DTOs.Auth;

public class LoginRequest
{
    [Required(ErrorMessage = "Identifier (email | phone number | username) is required")]
    public required string Identifier { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public required string Password { get; set; }
}