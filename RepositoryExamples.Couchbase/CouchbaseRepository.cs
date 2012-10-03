using System.Linq;
using Couchbase;
using Enyim.Caching.Memcached;
using Examples.Core.Repositories;

namespace RepositoryExamples.Couchbase
{
    public class CouchbaseRepository:IRepository
    {
        private readonly CouchbaseClient _couchbase;

        public CouchbaseRepository(CouchbaseClient couchbase)
        {
            _couchbase = couchbase;
        }

        public IQueryable<T> Find<T>() where T : IEntity, new()
        {
            throw new System.NotImplementedException("Searching is not implemented in this version");
        }

        public T Get<T>(object key) where T : IEntity, new()
        {
            var result = _couchbase.ExecuteGet<T>(key.ToString());

            return result.Value;
        }

        public void Save<T>(T value) where T : IEntity, new()
        {
            var result =_couchbase.ExecuteStore(StoreMode.Set, value.Id, value);
        }

        public void Delete<T>(T value) where T : IEntity, new()
        {
            var result = _couchbase.ExecuteRemove(value.Id);
        }
    }
}