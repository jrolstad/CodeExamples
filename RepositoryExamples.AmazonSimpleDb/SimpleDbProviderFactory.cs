using Directus.SimpleDb.Providers;
using Examples.Core.Repositories;

namespace RepositoryExamples.AmazonSimpleDb
{
    public class SimpleDbProviderFactory
    {
        private readonly string _awsAccessKey;
        private readonly string _awsSecretKey;

        public SimpleDbProviderFactory(string awsAccessKey, string awsSecretKey)
        {
            _awsAccessKey = awsAccessKey;
            _awsSecretKey = awsSecretKey;
        }

        public SimpleDBProvider<T,object> Build<T>() where T : IEntity, new()
        {
            var instance = new SimpleDBProvider<T, object>(_awsAccessKey, _awsSecretKey);

            return instance;
        }
    }
}