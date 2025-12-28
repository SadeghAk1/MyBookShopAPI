using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Exeptions
{
    public class BaseDomainException:Exception
    {
        public BaseDomainException():base("اسلاگ تکراری است")
        {
                
        }
        public BaseDomainException(string message):base(message)
        {

        }
    }
}
