using NHibernate;
using NHibernate.Cfg;
using CSS.OpusForce.Repository.NHibernate.SessionStorage;

namespace CSS.OpusForce.Repository.NHibernate.Factories
{
    public class SessionFactory
    {
        private static ISessionFactory _sessionFactory;

        public static void Init()
        {
            if (_sessionFactory == null)
            {
                Configuration config = new Configuration();
                config.AddAssembly(@"CSS.OpusForce.Repository.NHibernate");

                config.Configure();

                _sessionFactory = config.BuildSessionFactory();
            }
        }

        private static ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null)
            {
                Init();
            }

            return _sessionFactory;
        }

        private static ISession GetNewSession()
        {
            return GetSessionFactory().OpenSession();
        }

        public static ISession GetCurrentSession()
        {
            ISessionStorageContainer sessionStorageContainer = SessionStorageFactory.GetStorageContainer();

            ISession currentSession = sessionStorageContainer.GetCurrentSession();

            if (currentSession == null)
            {
                currentSession = GetNewSession();
                sessionStorageContainer.Store(currentSession);
            }

            return currentSession;
        }
    }
}
