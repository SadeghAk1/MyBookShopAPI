using MediatR;

namespace Shop.Domain.Common
{
    public class BaseDomainEvent:INotification
    {
        public DateTime CreationDate {  get;protected set; }
        public BaseDomainEvent()
        {
            CreationDate = DateTime.Now;
        }
    }
}
