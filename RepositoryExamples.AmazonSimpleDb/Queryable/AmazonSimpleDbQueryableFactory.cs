using System.Linq;
using RepositoryExamples.AmazonSimpleDb.Mappers;

namespace RepositoryExamples.AmazonSimpleDb.Queryable
{
    public class AmazonSimpleDbQueryableFactory
    {
        public IQueryable<T> Build<T>()
        {
            var queryable = new AmazonSimpleDbQueryable<T>(new AmazonSimpleDbQueryProvider<T>(new ExpressionMapper()));

            return queryable;
        }
    }
}