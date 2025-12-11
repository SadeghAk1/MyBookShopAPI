using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Users.Services
{
    public interface IUserDomainService
    {
        bool IsEmailExist(string email);    
        bool IsPhoneNumberExist(string phoneNumber);    
    }
}
