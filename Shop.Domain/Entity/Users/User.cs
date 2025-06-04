using Shop.Domain.Entity.Common;
using Shop.Domain.Entity.Rbac;

namespace Shop.Domain.Entity.Users;

public class User : BaseModel
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public string? PasswordHash { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}