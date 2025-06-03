using Shop.Domain.Entity.Common;

namespace Shop.Domain.Entity.Users;

public class User : BaseModel
{
    public string  Username { get; set; } = default!;
    public string  Email { get; set; } = default!;
    public string  PasswordHash { get; set; } = default!;
    public string? PhoneNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool IsActive { get; set; } = true;
}