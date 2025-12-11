using Shop.Domain.Common;
using Shop.Domain.Common.Exeptions;
using System;

namespace Shop.Domain.Users.Entities;

public class UserAddress:BaseEntity
{
    #region Properties
    public long UserId { get; internal set; }
    public string Province { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string PostalAddress { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string NationalCode { get; private set; }
    public bool ActiveAddress { get; private set; }
    #endregion
    public UserAddress(/*long userId,*/ string province, string city, string postalCode, string postalAddress, string phoneNumber, string name, string family, string nationalCode)
    {
        //UserId = userId;
        Guard(province, city, postalCode, postalAddress, phoneNumber, name, family, nationalCode);

        Province = province;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
        ActiveAddress = false;
    }
   public void Edit(string province, string city, string postalCode, string postalAddress, string phoneNumber, string name, string family, string nationalCode)
    {
        Guard(province, city, postalCode, postalAddress, phoneNumber, name, family, nationalCode);
        Province = province;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
    }
    public void SetActive()
    {
        ActiveAddress = true;
    }
    private void Guard(string province, string city, string postalCode, string postalAddress, string phoneNumber, string name, string family, string nationalCode)
    {
        NullOrEmptyDomainDataException.CheckString(province, nameof(province));
        NullOrEmptyDomainDataException.CheckString(city, nameof(city));
        NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
        NullOrEmptyDomainDataException.CheckString(postalAddress, nameof(postalAddress));
        NullOrEmptyDomainDataException.CheckString(name, nameof(name));
        NullOrEmptyDomainDataException.CheckString(family, nameof(family));
        NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
        if (nationalCode.IsValidNatinalCode() == false)
            throw new InvalidDomainDateException("شماره ملی نامعتبر است.");
    }
}
