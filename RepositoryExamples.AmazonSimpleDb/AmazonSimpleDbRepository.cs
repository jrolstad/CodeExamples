using System.Linq;
using Examples.Core.Repositories;


namespace RepositoryExamples.AmazonSimpleDb
{
    public class AmazonSimpleDbRepository:IRepository
    {
        private readonly SimpleDbProviderFactory _providerFactory;

        public AmazonSimpleDbRepository(SimpleDbProviderFactory providerFactory )
        {
            _providerFactory = providerFactory;
        }

        public IQueryable<T> Find<T>() where T : IEntity, new()
        {
            var provider = _providerFactory.Build<T>();

            return provider
                .Get()
                .AsQueryable();

        }

        public T Get<T>(object key) where T : IEntity, new()
        {
            var provider = _providerFactory.Build<T>();

            return provider.Get(key);

        }

        public void Save<T>(T value) where T : IEntity, new()
        {
            var provider = _providerFactory.Build<T>();

            provider.Save(new[]{value});
        }

        public void Delete<T>(T value) where T : IEntity, new()
        {
            var provider = _providerFactory.Build<T>();

            provider.Delete(new[] { value.Id });
        }
    }
}