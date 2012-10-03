using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Examples.Core.Mapping;
using Examples.Core.Repositories;

namespace RepositoryExamples.AmazonSimpleDb.Queryable
{
    public class AmazonSimpleDbQueryProvider<T> : IQueryProvider
    {
        private readonly IMapper<Expression, string> _expressionMapper;

        public AmazonSimpleDbQueryProvider( IMapper<Expression, string> expressionMapper)
        {
            _expressionMapper = expressionMapper;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return GetQueryable<object>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return GetQueryable<TElement>(expression);
        }

        private IQueryable<TElement> GetQueryable<TElement>(Expression expression)
        {
            return new AmazonSimpleDbQueryable<TElement>(this,expression);
        }

        public object Execute(Expression expression)
        {
            return ExecuteQuery<object>(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return ExecuteQuery<TResult>(expression);
        }

        private TResult ExecuteQuery<TResult>(Expression expression)
        {
            var queryText = _expressionMapper.Map(expression);
            var result = QuerySimpleDb(queryText);

            return (TResult) result;

        }

        private static IEnumerable<T> QuerySimpleDb(string queryText)
        {
            var instance1 = Activator.CreateInstance<T>();
            var instance2 = Activator.CreateInstance<T>();
            return new List<T>{instance1,instance2};
        }
    }
}