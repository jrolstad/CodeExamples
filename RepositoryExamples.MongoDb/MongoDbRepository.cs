using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using RepositoryExamples.Core;

namespace RepositoryExamples.MongoDb
{
    public class MongoDbRepository : IRepository
    {
        private readonly MongoDatabase _database;

        public MongoDbRepository(MongoDatabase database)
        {
            _database = database;
        }

        public IQueryable<T> Find<T>() where T : IEntity
        {
            return _database
                .GetCollection<T>(typeof(T).Name)
                .AsQueryable<T>();
        }

        public T Get<T>(object key) where T : IEntity
        {
            var identifier = key == null ? null : key.ToString();

            return _database.GetCollection<T>(typeof(T).Name)
                .FindOneAs<T>(Query.EQ("_id", identifier));
        }

        public void Save<T>(T value) where T : IEntity
        {
            _database
                .GetCollection<T>(typeof(T).Name)
                .Save(value);
        }

        public void Delete<T>(T value) where T : IEntity
        {
            _database
                .GetCollection<T>(typeof(T).Name)
                .Remove(Query.EQ("_id", value.Id));
        }
    }
}
