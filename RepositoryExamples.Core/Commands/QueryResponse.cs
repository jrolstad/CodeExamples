using System.Collections.Generic;
using System.Linq;

namespace Examples.Core.Commands
{
    public class QueryResponse<T>
    {
        public IEnumerable<T> QueryResults { get; set; }

        public QueryResponse()
        {
            this.QueryResults = Enumerable.Empty<T>().ToList().AsReadOnly();
        }
    }
}