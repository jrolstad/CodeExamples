using System.Collections.Generic;
using System.Linq;

namespace Examples.Core.Mapping
{
    public static class MapperExtensions
    {
        public static IEnumerable<TOut> MapMany<TIn, TOut>(this IMapper<TIn, TOut> mapper, IEnumerable<TIn> source)
        {
            return source.Select(mapper.Map);
        }
    }
}