using System.Linq;
using System.Collections.Generic;

using NHibernate;
using NHibernate.Linq;
using CSS.Infrastructure.Domain;
using CSS.Infrastructure.UnitOfWork;
using CSS.Infrastructure.Querying;
using CSS.OpusForce.Repository.NHibernate.Factories;


namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public abstract class Repository<T, EntityKey> where T : IAggregateRoot
    {
        private IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public object Add(T entity)
        {
            return SessionFactory.GetCurrentSession().Save(entity);
        }

        public void Remove(EntityKey Id)
        {
            var entity = SessionFactory.GetCurrentSession().Load<T>(Id);
            SessionFactory.GetCurrentSession().Delete(entity);
        }

        public void Save(T entity)
        {
            SessionFactory.GetCurrentSession().Clear();
            SessionFactory.GetCurrentSession().Update(entity);
        }

        public T FindBy(EntityKey Id)
        {
            return SessionFactory.GetCurrentSession().Get<T>(Id);
        }

        public IEnumerable<T> FindAll()
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));

            return (List<T>)criteriaQuery.List<T>();
        }

        public IEnumerable<T> FindAll(int index, int count)
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));

            return (List<T>)criteriaQuery.SetFetchSize(count).SetFirstResult(index).List<T>();
        }

        public IEnumerable<T> FindBy(Query query)
        {
            ICriteria criteriaQuery =
                     SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));

            AppendCriteria(criteriaQuery);

            query.TranslateIntoNHQuery<T>(criteriaQuery);

            return criteriaQuery.List<T>();
        }

        public IEnumerable<T> FindBy(Query query, int index, int count)
        {
            ICriteria criteriaQuery =
                     SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));

            AppendCriteria(criteriaQuery);

            query.TranslateIntoNHQuery<T>(criteriaQuery);

            return criteriaQuery.SetFetchSize(count).SetFirstResult(index).List<T>();
        }

        public virtual void AppendCriteria(ICriteria criteria)
        {

        }        
    }
}
