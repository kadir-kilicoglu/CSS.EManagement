namespace CSS.Infrastructure.Domain
{
    public interface IRepository<T, TId> : IReadOnlyRepository<T, TId>
                                    where T : IAggregateRoot
    {
        void Save(T entity);
        object Add(T entity);
        void Remove(TId id);
    }
}
