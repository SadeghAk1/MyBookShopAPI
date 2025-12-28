using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Exeptions
{
    public class InvalidDomainDateException:Exception
    {
        public InvalidDomainDateException(string message):base(message) { }
       
    }
}
