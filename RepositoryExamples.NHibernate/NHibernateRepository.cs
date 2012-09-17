using System.Linq;
using NHibernate;
using NHibernate.Linq;
using RepositoryExamples.Core;

namespace RepositoryExamples.NHibernate
{
    public class NHibernateRepository: IRepository
    {
        private readonly bool _disposeSession;
        private readonly ISession _session;

        public NHibernateRepository(ISession session, bool disposeSession = true)
        {
            _disposeSession = disposeSession;
            _session = session;
        }

        public T Get<T>(object key) where T : IEntity
        {
            return _session.Get<T>(key);
        }

        public void Save<T>(T value) where T : IEntity
        {
            _session.SaveOrUpdate(value);
        }

        public void Delete<T>(T value) where T : IEntity
        {
            _session.Delete(value);
        }

        public void DeleteByKey<T>(object key)
        {
            _session.Delete(typeof(T).Name, key);
        }

        public IQueryable<T> Find<T>() where T : IEntity
        {
            return _session.Query<T>();
        }

        public void Dispose()
        {
            if (_disposeSession)
                _session.Dispose();
        }
    }
}