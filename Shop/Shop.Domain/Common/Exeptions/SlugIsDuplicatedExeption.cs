using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Common.Exeptions
{
    public class SlugIsDuplicatedExeption:BaseDomainException
    {
        public SlugIsDuplicatedExeption()
        {
                
        }
        public SlugIsDuplicatedExeption(string message):base(message) 
        {
                
        }
    }
}
