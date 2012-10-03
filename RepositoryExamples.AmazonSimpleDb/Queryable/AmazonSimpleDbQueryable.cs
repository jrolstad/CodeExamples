using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RepositoryExamples.AmazonSimpleDb.Queryable
{
    public class AmazonSimpleDbQueryable<T>:IQueryable<T>
    {
        public AmazonSimpleDbQueryable(IQueryProvider queryProvider)
        {
            Provider = queryProvider;
            Expression = Expression.Constant(this);
        }

        public AmazonSimpleDbQueryable(IQueryProvider queryProvider, Expression expression)
        {
            Provider = queryProvider;
            Expression = expression;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return Provider
                .Execute<IEnumerable<T>>(Expression)
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Expression Expression { get; private set; }

        public Type ElementType { get { return typeof (T); }}

        public IQueryProvider Provider { get; private set; }
    }
}