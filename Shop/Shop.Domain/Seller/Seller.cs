using Shop.Domain.Common;
using Shop.Domain.Seller.Enums;
namespace Shop.Domain.Seller
{
    public class Seller:AggregateRoot
    {
        public long UserId { get;private set; }
        public string ShopName { get;private set; }
        public SellerStatus Status { get;private set; }
        public List<SellerInventory> SellerInventories { get;private set; }
        public void ChangaeStatus(SellerStatus status)
        {
            Status=status;
        }
    }
}
