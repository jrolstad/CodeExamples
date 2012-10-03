using System;
using Amazon.SimpleDB.Model;
using Examples.Core.Mapping;
using Examples.Core.Repositories;

namespace RepositoryExamples.AmazonSimpleDb.Mappers
{
    public class DeleteAttributesRequestMapper : IMapper<IEntity, DeleteAttributesRequest>
    {
        private readonly IMapper<Type, string> _domainNameMapper;

        public DeleteAttributesRequestMapper(IMapper<Type, string> domainNameMapper)
        {
            _domainNameMapper = domainNameMapper;
        }

        public DeleteAttributesRequest Map(IEntity toMap)
        {
            var domainName = _domainNameMapper.Map(toMap.GetType());

            var request = new DeleteAttributesRequest()
                .WithDomainName(domainName)
                .WithItemName(toMap.Id);

            return request;
        }
    }
}