using Common.Domain;
using Shop.Domain.Users.Enums;


namespace Shop.Domain.Users.Entities;

public class Wallet:BaseEntity
{
    #region Properties
    public long UserId { get; internal set; }
    public int Price { get; private set; }
    public string Description { get; private set; }
    public bool IsFinally { get; private set; }
    public DateTime FinallyDate { get; private set; }
    public WalletType WalletType { get; private set; }
    #endregion
    public Wallet(int price, string description, bool isFinally, DateTime finallyDate, WalletType walletType)
    {
        if (price < 500)
        {
            throw new InvalidDataException("مبلغ پایین است");
        }
        Price = price;
        Description = description;
        IsFinally = isFinally;
        FinallyDate = finallyDate;
        WalletType = walletType;
    }
    
    public void Finally(string refcode)
    {
        IsFinally= true;
        FinallyDate= DateTime.Now;
        Description += $"کدپیگیری : {refcode}";
    }
    public void Finally()
    {
        IsFinally = true;
        FinallyDate = DateTime.Now;
    }
}
