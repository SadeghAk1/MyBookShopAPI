using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Orders.ValueObjects
{
    public class OrderDiscount:BaseValueObject
    {
        public string DiscountTitle {  get;private set; }
        public int DiscountAmount {  get;private set; }
        public OrderDiscount(string discountTitle, int discountAmount)
        {
            DiscountTitle = discountTitle;
            DiscountAmount = discountAmount;
        }
    }
}
