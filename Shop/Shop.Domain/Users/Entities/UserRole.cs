using Shop.Domain.Common;

namespace Shop.Domain.Users.Entities;

public class UserRole:BaseEntity
{
    #region Properties
    public long UserId { get; internal set; }
    public long RoleId { get; private set; }
    #endregion
    public UserRole(long roleId)
    {
        RoleId = roleId;
    }
    
}
