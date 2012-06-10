using CSS.Infrastructure.Domain;

namespace CSS.Infrastructure.UnitOfWork
{
    public interface IUnitOfWorkRepository
    {
        void PersistAdd(IAggregateRoot entity);
        void PersistUpdate(IAggregateRoot entity);
        void PersistDelete(IAggregateRoot entity);
    }
}
