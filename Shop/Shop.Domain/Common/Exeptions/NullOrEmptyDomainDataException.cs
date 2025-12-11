using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Common.Exeptions
{
    public class NullOrEmptyDomainDataException:Exception
    {
        public NullOrEmptyDomainDataException(string message):base(message) 
        {
            
        }
        public static void CheckString(string value, string nameOfField)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new NullOrEmptyDomainDataException($"{nameOfField} نباید خالی یا null باشد.");
        }
    }
}
