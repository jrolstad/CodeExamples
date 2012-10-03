using System.Linq;
using Amazon.SimpleDB;
using Amazon.SimpleDB.Model;
using Examples.Core.Mapping;
using Examples.Core.Repositories;
using RepositoryExamples.AmazonSimpleDb.Mappers;
using RepositoryExamples.AmazonSimpleDb.Queryable;

namespace RepositoryExamples.AmazonSimpleDb
{
    public class AmazonSimpleDbRepository:IRepository
    {
        private readonly AmazonSimpleDB _client;
        private readonly IMapper<IEntity, DeleteAttributesRequest> _deleteRequestMapper;
        private readonly IMapper<IEntity, PutAttributesRequest> _putAttributeRequestMapper;
        private readonly AmazonSimpleDbQueryableFactory _queryableFactory;

        public AmazonSimpleDbRepository(AmazonSimpleDB client,
            IMapper<IEntity,DeleteAttributesRequest> deleteRequestMapper,
            IMapper<IEntity,PutAttributesRequest> putAttributeRequestMapper,
            AmazonSimpleDbQueryableFactory queryableFactory)
        {
            _client = client;
            _deleteRequestMapper = deleteRequestMapper;
            _putAttributeRequestMapper = putAttributeRequestMapper;
            _queryableFactory = queryableFactory;
        }

        public IQueryable<T> Find<T>() where T : IEntity
        {
            var queryable = _queryableFactory.Build<T>();

            return queryable;

        }

        public T Get<T>(object key) where T : IEntity
        {
            var entity = Find<T>()
                .FirstOrDefault(e => e.Id == key.ToString());

            return entity;
        }

        public void Save<T>(T value) where T : IEntity
        {
            var request = _putAttributeRequestMapper.Map(value);

            var response = _client.PutAttributes(request);
        }

        public void Delete<T>(T value) where T : IEntity
        {
            var request = _deleteRequestMapper.Map(value);

            var response = _client.DeleteAttributes(request);
        }
    }
}