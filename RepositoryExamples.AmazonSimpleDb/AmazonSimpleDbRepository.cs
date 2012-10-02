using System.Linq;
using Amazon.SimpleDB;
using Examples.Core.Repositories;

namespace RepositoryExamples.AmazonSimpleDb
{
    public class AmazonSimpleDbRepository:IRepository
    {
        private readonly AmazonSimpleDB _client;

        public AmazonSimpleDbRepository(Amazon.SimpleDB.AmazonSimpleDB client)
        {
            _client = client;
        }

        public IQueryable<T> Find<T>() where T : IEntity
        {

        }

        public T Get<T>(object key) where T : IEntity
        {
           
        }

        public void Save<T>(T value) where T : IEntity
        {

        }

        public void Delete<T>(T value) where T : IEntity
        {

        }
    }
}