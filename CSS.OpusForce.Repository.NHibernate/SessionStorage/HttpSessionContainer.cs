using NHibernate;
using System.Web;

namespace CSS.OpusForce.Repository.NHibernate.SessionStorage
{
    public class HttpSessionContainer : ISessionStorageContainer
    {
        private string _sessionKey = @"NHSession";

        public ISession GetCurrentSession()
        {
            ISession session = null;

            if (HttpContext.Current.Items.Contains(_sessionKey))
            {
                session = (ISession)HttpContext.Current.Items[_sessionKey];
            }

            return session;
        }

        public void Store(global::NHibernate.ISession session)
        {
            if (HttpContext.Current.Items.Contains(_sessionKey))
                HttpContext.Current.Items[_sessionKey] = session;
            else
                HttpContext.Current.Items.Add(_sessionKey, session);
        }
    }
}
