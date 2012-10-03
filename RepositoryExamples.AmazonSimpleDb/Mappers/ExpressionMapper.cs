using System.Linq.Expressions;
using Examples.Core.Mapping;

namespace RepositoryExamples.AmazonSimpleDb.Mappers
{
    public class ExpressionMapper:IMapper<Expression,string>
    {
        public string Map(Expression toMap)
        {
            return "";
        }
    }
}