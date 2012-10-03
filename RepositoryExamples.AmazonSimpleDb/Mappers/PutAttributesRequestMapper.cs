using System;
using Amazon.SimpleDB.Model;
using Examples.Core.Mapping;
using Examples.Core.Repositories;

namespace RepositoryExamples.AmazonSimpleDb.Mappers
{
    public class PutAttributesRequestMapper:IMapper<IEntity,PutAttributesRequest>
    {
        private readonly IMapper<Type, string> _domainNameMapper;
        private readonly IMapper<IEntity, ReplaceableAttribute[]> _replaceableAttributeMapper;

        public PutAttributesRequestMapper(IMapper<Type, string> domainNameMapper, IMapper<IEntity,ReplaceableAttribute[]> replaceableAttributeMapper)
        {
            _domainNameMapper = domainNameMapper;
            _replaceableAttributeMapper = replaceableAttributeMapper;
        }

        public PutAttributesRequest Map(IEntity toMap)
        {
            var domainName = _domainNameMapper.Map(toMap.GetType());
            var attributes = _replaceableAttributeMapper.Map(toMap);


            var request = new PutAttributesRequest()
                .WithDomainName(domainName)
                .WithItemName(toMap.Id)
                .WithAttribute(attributes);

            return request;
        }
    }
}