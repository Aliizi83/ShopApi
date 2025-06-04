using Shop.Domain.Entity.Common;
using Shop.Domain.Entity.Users;

namespace Shop.Domain.Entity.Rbac;

public class UserRole : BaseModel
{
    public int UserId { get; set; }
    public User User{ get; set; } = default!;

    public int RoleId { get; set; }
    public Role Role { get; set; } = default!;
}