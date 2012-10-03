using System;
using System.Linq;
using Examples.Core.Mapping;
using RepositoryExamples.AmazonSimpleDb.Attributes;

namespace RepositoryExamples.AmazonSimpleDb.Mappers
{
    public class DomainNameMapper:IMapper<Type,string>
    {
        public string Map(Type toMap)
        {
            // See if there is a domain name specified
            var domainName = toMap.Name;
            var domainAttribute = toMap.GetCustomAttributes(typeof(DomainNameAttribute), true).FirstOrDefault() as DomainNameAttribute;

            // Return either the defined domain name or the given type name
            var domainNameForType = domainAttribute != null ? domainAttribute.DomainName : domainName;

            return domainNameForType;
        }
    }
}