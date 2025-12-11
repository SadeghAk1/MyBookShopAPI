using Shop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Orders.ValueObjects
{
    public class ShippingMethod: BaseValueObject
    {
        public string ShippingType {  get;private set; }
        public int ShippingCost {  get;private set; }
        public ShippingMethod(string shippingType, int shippingCost)
        {
            ShippingType = shippingType;
            ShippingCost = shippingCost;
        }
    }
}
