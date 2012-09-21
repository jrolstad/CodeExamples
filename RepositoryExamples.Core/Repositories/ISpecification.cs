using System;
using System.Linq.Expressions;

namespace Examples.Core.Repositories
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> IsSatisfied();
    }
}