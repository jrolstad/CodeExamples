using System.Collections.Generic;
using System.Linq;

namespace Examples.Core.Visitors
{
    public static class VisitorExtensions
    {
        public static IVisitor<T> VisitMany<T>(this IVisitor<T> visitor, IEnumerable<T> targets)
        {
            targets.ToList().ForEach(visitor.Visit);

            return visitor;
        }
    }
}