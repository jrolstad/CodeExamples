using System.Linq;
using Raven.Client;
using RepositoryExamples.Core;

namespace RepositoryExamples.RavenDb
{
    /// <summary>
    /// Repository around RavenDB
    /// </summary>
    public class RavenDbRepository : IRepository
    {
        private readonly IDocumentStore _documentStore;

        /// <summary>
        /// Constructor with arguments
        /// </summary>
        /// <param name="documentStore">Document store to use for persistence</param>
        public RavenDbRepository(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        /// <summary>
        /// Exposes queryable to search with
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> Find<T>() where T : IEntity
        {
            var session = GetSession();

            return session.Query<T>();
        }

        /// <summary>
        /// Finds a given item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">Item id</param>
        /// <returns></returns>
        public T Get<T>(object key) where T : IEntity
        {
            var session = GetSession();

            var keyAsString = key.ToString();
            return session.Load<T>(keyAsString);
        }

        /// <summary>
        /// Saves a given item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">Item to save</param>
        public void Save<T>(T value)
        {
            var session = GetSession();
            session.Store(value);
            session.SaveChanges();
        }

        /// <summary>
        /// Deletes a given item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">Item to delete</param>
        public void Delete<T>(T value)
        {
            var session = GetSession();
            session.Delete(value);
            session.SaveChanges();
        }

        private IDocumentSession _session;
        private IDocumentSession GetSession()
        {
            return _session ?? (_session = _documentStore.OpenSession());
        }
    }
}