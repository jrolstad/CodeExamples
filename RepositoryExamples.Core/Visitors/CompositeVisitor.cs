using System.Collections.Generic;
using System.Linq;

namespace Examples.Core.Visitors
{
    public class CompositeVisitor<T> : IVisitor<T>
    {
        private readonly IEnumerable<IVisitor<T>> _visitors;

        public CompositeVisitor(IEnumerable<IVisitor<T>> visitors)
        {
            _visitors = visitors;
        }

        public void Visit(T item)
        {
            this._visitors
                .ToList()
                .ForEach(
                    row => row.Visit(item)
                );
        }
    }
}