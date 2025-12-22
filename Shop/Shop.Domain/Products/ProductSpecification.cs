using Shop.Domain.Common;
using Shop.Domain.Common.Exeptions;

namespace Shop.Domain.Products
{
    public class ProductSpecification : BaseEntity
    {
        public long ProductId { get; internal set; }
        public string Key { get; private set; }
        public string Value { get; private set; }

        protected ProductSpecification() { }

        public ProductSpecification(string key, string value)
        {
          NullOrEmptyDomainDataException.CheckString(key, nameof(key));
          NullOrEmptyDomainDataException.CheckString(value, nameof(value));
            Key = key;
            Value = value;
        }
    }

}
