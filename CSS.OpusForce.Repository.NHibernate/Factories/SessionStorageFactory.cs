using CSS.OpusForce.Repository.NHibernate.SessionStorage;

namespace CSS.OpusForce.Repository.NHibernate.Factories
{
    public static class SessionStorageFactory
    {
        public static ISessionStorageContainer sessionStorageContainer;

        public static ISessionStorageContainer GetStorageContainer()
        {
            if (sessionStorageContainer == null)
            {
                sessionStorageContainer = new HttpSessionContainer();
            }

            return sessionStorageContainer;
        }        
    }
}
