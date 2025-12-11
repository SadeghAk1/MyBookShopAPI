using Shop.Domain.Common;
using Shop.Domain.Common.Exeptions;


namespace Shop.Domain.Orders.Entities
{
    public class OrderItem:BaseEntity
    {
        public long OrderId { get; internal set; }
        public long InventoryId { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Count { get; private set; }
        public decimal LineTotal => UnitPrice * Count;
        private OrderItem()
        {
            
        }
        private OrderItem(long orderId, long inventoryId, decimal unitPrice, int count)
        {
            PriceGuard(unitPrice);
            CountGuard(count);
            OrderId = orderId;
            InventoryId = inventoryId;
            UnitPrice = unitPrice;
            Count = count;
        }
        public void ChangeCount(int newcount)
        {
            CountGuard(newcount);
             Count = newcount;
        }
        public void SetPrice(decimal newUnitPrice)
        {
            PriceGuard(newUnitPrice);
            UnitPrice = newUnitPrice;
        }
        private void PriceGuard(decimal newUnitPrice)
        {
            if (newUnitPrice < 1)
            {
                throw new InvalidDomainDateException("مبلغ کالا نامعتبر است");
            }
        }
        private void CountGuard(int newcount)
        {
            if (newcount < 1)
            {
                throw new InvalidDomainDateException("تعداد کالا نامعتبر است");
            }
        }
    }
}
