using Common.Domain;
using Common.Domain.Exeptions;
using Shop.Domain.Seller.Enums;
using System;
namespace Shop.Domain.Seller
{
    public class Seller:AggregateRoot
    {
       
        public long UserId { get;private set; }
        public string ShopName { get;private set; }
        public string Nationalcode { get;private set; }
        public SellerStatus Status { get;private set; }
        public DateTime? LastUpdate { get; private set; }
        public List<SellerInventory> SellerInventories { get;private set; }
        private Seller()
        {

        }
        private Seller(long userId, string shopName, string nationalcode)
        {
            Guard(shopName, nationalcode);
            UserId = userId;
            ShopName = shopName;
            Nationalcode = nationalcode;
            SellerInventories= new List<SellerInventory>();
        }
        public void AddInventory(SellerInventory sellerInventory)
        {
            if (SellerInventories.Any(f => f.ProductId == sellerInventory.ProductId))
                throw new InvalidDomainDateException("شناسه محصول تکراری است .");
            SellerInventories.Add(sellerInventory);
        }
        public void EditInventory(SellerInventory newSellerInventory)
        {
           var currentSellerInventory = SellerInventories.FirstOrDefault(s=>s.Id == newSellerInventory.Id);
            if (currentSellerInventory != null)
            {
                SellerInventories.Remove(currentSellerInventory);
                SellerInventories.Add(newSellerInventory);
            }
        }
        public void DeleteInventory(long SellerInventoryId)
        {
            var currentSellerInventory = SellerInventories.FirstOrDefault(s => s.Id == SellerInventoryId);
            if (currentSellerInventory == null)
            {
                throw new NullOrEmptyDomainDataException("محصولی یافت نشد .");
            }
            SellerInventories.Remove(currentSellerInventory);
        }
        public void ChangeStatus(SellerStatus status)
        {
            Status=status;
            LastUpdate=DateTime.Now; 
        }
        public void Edit(string shopName,string nationalCode)
        {
            Guard(shopName,nationalCode);
            ShopName =shopName;
            Nationalcode=nationalCode;
        }
        public void Guard(string shopName, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(shopName,nameof(shopName));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
            if (IranianNationalIdChecker.IsValidNatinalCode(nationalCode)==false) {
                throw new InvalidDomainDateException("کد ملی نامعتبر است.");
            }
        }
    }
}
