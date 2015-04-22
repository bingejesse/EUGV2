using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

namespace Domain
{
    public class SessionManager
    {
        private static readonly ISessionFactory sessionFactory;
        static SessionManager()
        {
            sessionFactory = new Configuration().Configure().BuildSessionFactory();
        }
        public static ISession GetSession()
        {
            return sessionFactory.OpenSession();
        }
    }
}
