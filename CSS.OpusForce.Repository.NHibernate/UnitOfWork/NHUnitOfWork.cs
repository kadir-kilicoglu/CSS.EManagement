using System;
using NHibernate;
using CSS.Infrastructure.Domain;
using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Repository.NHibernate.Factories;

namespace CSS.OpusForce.Repository.NHibernate
{
    public class NHUnitOfWork : IUnitOfWork
    {

        public object RegisterAdd(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            return SessionFactory.GetCurrentSession().Save(entity);
        }

        public void RegisterUpdate(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            SessionFactory.GetCurrentSession().Update(entity);
        }

        public void RegisterDelete(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            SessionFactory.GetCurrentSession().Delete(entity);
        }

        public void Commit()
        {
            using (ITransaction transaction = SessionFactory.GetCurrentSession().BeginTransaction())
            {
                try
                {
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
