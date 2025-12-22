using Shop.Domain.Common;
using Shop.Domain.Common.Exeptions;

namespace Shop.Domain.Products
{
    public class ProductImage : BaseEntity
    {
        public long ProductId { get; internal set; }
        public string ImageName { get; private set; }
        public int Sequence { get; private set; }

        protected ProductImage() { }

        public ProductImage(string imageName, int sequence)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));   
         
            ImageName = imageName;
            Sequence = sequence;
        }
    }

}
