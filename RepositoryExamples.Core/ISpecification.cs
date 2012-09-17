using System;
using System.Linq.Expressions;

namespace RepositoryExamples.Core
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> IsSatisfied();
    }
}