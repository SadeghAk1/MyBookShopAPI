namespace Common.Domain
{
    public class BaseEntity
    {
        public long Id { get;private set; }
        public DateTime CreationDate { get;}
        public BaseEntity()
        {
            CreationDate = new DateTime();
        }
    }
    public class AggregateRoot : BaseEntity
    {
        private readonly List<BaseDomainEvent> _domaunEvents = new();
        public List<BaseDomainEvent> DomainEvents => _domaunEvents;
        public void AddDomainEvent(BaseDomainEvent domainEvent)
        {
            DomainEvents.Add(domainEvent);
        }
    }
}
