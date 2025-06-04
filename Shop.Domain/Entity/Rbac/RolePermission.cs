using Shop.Domain.Entity.Common;

namespace Shop.Domain.Entity.Rbac;

public class RolePermission : BaseModel
{
    public int RoleId { get; set; }
    public Role Role { get; set; } = default!;

    public int PermissionId { get; set; }
    public Permission Permission { get; set; } = default!;

}