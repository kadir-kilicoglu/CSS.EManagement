using CSS.Infrastructure.Domain;

namespace CSS.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        object RegisterAdd(IAggregateRoot entity, IUnitOfWorkRepository repository);
        void RegisterUpdate(IAggregateRoot entity, IUnitOfWorkRepository repository);
        void RegisterDelete(IAggregateRoot entity, IUnitOfWorkRepository repository);
        void Commit();
    }
}
