using Common.Domain;
using Common.Domain.Exeptions;
namespace Shop.Domain.Seller
{
    public class SellerInventory:BaseEntity
    {
        public long SellerId { get; private set; }
        public long ProductId { get; private set; }
        public int Count { get; private set; }
        public decimal Price { get; private set; }
        public SellerInventory(long sellerId, long productId, int count, decimal price)
        {
            if(price<1 || count < 0)
            {
                throw new InvalidDomainDateException("قیمت محصول یا تعداد آن معتبر نیست.");
            }
            SellerId = sellerId;
            ProductId = productId;
            Count = count;
            Price = price;
        }

    }
}
