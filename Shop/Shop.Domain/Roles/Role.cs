using Common.Domain;
using Common.Domain.Exeptions;

namespace Shop.Domain.Roles
{
    public class Role:AggregateRoot
    {
        public string Name { get; private set; }
        public List<RolePermission> RolePermissions { get; private set; }
        private Role()
        {
            
        }
        public Role(string name, List<RolePermission> rolePermissions)
        {
            NullOrEmptyDomainDataException.CheckString(name, nameof(Name));
            Name = name;
            RolePermissions = rolePermissions;
        }
        public Role(string name)
        {
            NullOrEmptyDomainDataException.CheckString(name, nameof(Name));
            Name = name;
            RolePermissions = new List<RolePermission>();
        }
      public void Edit(string name)
        {
            NullOrEmptyDomainDataException.CheckString(name,nameof(Name));
            Name=name;
        }
        public void SetPermission(List<RolePermission> rolePermissions)
        {
           
            RolePermissions = rolePermissions;
        }
    }
   
}
