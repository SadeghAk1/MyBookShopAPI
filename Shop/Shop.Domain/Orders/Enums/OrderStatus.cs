using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Orders.Enums
{
    public enum OrderStatus
    {
        Pending,
        Finally,
        Shipping,
        Regected
    }
}
