using Shop.Domain.Common;
using Shop.Domain.Roles.Enums;

namespace Shop.Domain.Roles
{
    public class RolePermission:BaseEntity
    {
        public long RoleId { get; set; }
        public Permission Permission { get; set; }
    }
}
