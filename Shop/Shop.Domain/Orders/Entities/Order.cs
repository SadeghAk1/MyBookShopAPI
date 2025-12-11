using Shop.Domain.Common;
using Shop.Domain.Orders.Enums;
using Shop.Domain.Orders.ValueObjects;
using System.Linq;


namespace Shop.Domain.Orders.Entities
{
    public class Order : AggregateRoot
    {
        public Order(long userId)
        {
            UserId = userId;
            Status = OrderStatus.Pending;
            Items = new List<OrderItem>();
        }

        public long UserId { get; private set; }
        public OrderStatus Status { get;private set; }
        public DateTime?LastUpdate { get;private set; }
        public OrderDiscount? OrderDiscount { get; private set; }
        public ShippingMethod? ShippingMethod { get; private set; }

        public OrderAddress? OrderAddress { get; private set; }
        public decimal TottalPrice
        {
            get
            {
                var totalPrice = Items.Sum(x => x.LineTotal);
                if (ShippingMethod != null)
                {
                    totalPrice += ShippingMethod.ShippingCost;
                }
                if (OrderDiscount != null)
                {
                    totalPrice -= OrderDiscount.DiscountAmount;
                }
                return totalPrice;
            }
        }
        public int ItemCount => Items.Count;
        public List<OrderItem> Items { get; private set; }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }
        public void RemoveItem(long itemId)
        {
            var currentItem = Items.FirstOrDefault(x => x.Id == itemId);
            if (currentItem != null)
            {

                Items.Remove(currentItem);
            }
        }

        public void ChangeCountItem(long itemId,int count)
        {
            var currentItem = Items.FirstOrDefault(x => x.Id == itemId);
            if (currentItem != null)
            {
                throw new ArgumentNullException(nameof(currentItem));
            }
            currentItem.ChangeCount(count);
        }
        public void ChangeStatus(OrderStatus status)
        {
            Status= status;
            LastUpdate= DateTime.Now;
        }
        public void CheckOut(OrderAddress orderAddress)
        {
            OrderAddress= orderAddress;
        }
    }
}
