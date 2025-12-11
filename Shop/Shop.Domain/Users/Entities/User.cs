using Shop.Domain.Common;
using Shop.Domain.Common.Exeptions;
using Shop.Domain.Users.Enums;
using Shop.Domain.Users.Services;

namespace Shop.Domain.Users.Entities;

public class User : AggregateRoot
{
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public Gender Gender { get; private set; }
    public List<UserAddress> UserAddresses { get; private set; }
    public List<UserRole> UserRoles { get; private set; }
    public List<Wallet> Wallets { get; private set; }
    public User(string name, string family, string phoneNumber, string email, string password, Gender gender, IUserDomainService userDomainService)
    {
        Guard(phoneNumber, email, userDomainService);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
        Gender = gender;
    }
    public static User Create(string phoneNumber, string email,string password, IUserDomainService userDomainService)
    {
        return new User("", "", phoneNumber, email,password, Gender.Unknown, userDomainService);
    }
    public void Edit(string name, string family, string phoneNumber, string email, Gender gender,IUserDomainService userDomainService)
    {
        Guard(phoneNumber, email, userDomainService);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Gender = gender;
    }
    public void AddAddress(UserAddress address)
    {
        address.UserId = Id;
        UserAddresses.Add(address);
    }
    public void EditAddress(UserAddress address)
    {
        var userAddress=UserAddresses.FirstOrDefault(a=>a.Id==address.Id);
        if (userAddress!=null)
            throw new NullOrEmptyDomainDataException("Userddress not found!");
        UserAddresses.Remove(userAddress);
        UserAddresses.Add(address);
    }
    public void DeleteAddress(long addressId)
    {
        var userAddress = UserAddresses.FirstOrDefault(a => a.Id ==addressId);
        if (userAddress != null)
            throw new NullOrEmptyDomainDataException("Userddress not found!");
        UserAddresses.Remove(userAddress);
    }
    public void ChargeWallet(Wallet wallet)
    {
        wallet.UserId = Id;
       Wallets.Add(wallet);
    }
    public void AddRoles(List<UserRole> roles)
    {
        roles.ForEach(f=>f.UserId = Id);
        UserRoles.Clear();
        UserRoles.AddRange(roles);
    }
    public void Guard(string phoneNumber, string email,IUserDomainService userDomainService)
    {
        NullOrEmptyDomainDataException.CheckString(phoneNumber,nameof(phoneNumber));
        NullOrEmptyDomainDataException.CheckString(email, nameof(email));
        if (phoneNumber.Length != 11)
            throw new InvalidDomainDateException("شماره مویابل نامعتبر است.");
        if (email.IsValidEmail())
            throw new InvalidDomainDateException("ایمیل نامعتبر است.");
        if (phoneNumber != PhoneNumber)
        {
            if (userDomainService.IsPhoneNumberExist(phoneNumber) == true)
            {
                throw new InvalidDomainDateException("شماره مویابل تکراری است.");
            }
        }
        if (email != Email)
        {
            if (userDomainService.IsPhoneNumberExist(email) == true)
            {
                throw new InvalidDomainDateException("شماره مویابل تکراری است.");
            }
        }

    }
}
