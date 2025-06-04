using Shop.Domain.Entity.Common;

namespace Shop.Domain.Entity.Rbac;

public class Role : BaseModel
{
    public string Name { get; set; } = default!;
    public string Title { get; set; } = default!;

    public ICollection<RolePermission> RolePermissions { get; set; } = default!;
    public ICollection<UserRole> UserRoles { get; set; } = default!;
}