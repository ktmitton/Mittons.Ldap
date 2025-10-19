using System;
using System.Collections.Generic;
using System.Linq;
using Mittons.ActiveDirectory.Search.Operators;

namespace Mittons.ActiveDirectory.Search.Filters
{
    public class CompoundFilter : IFilterComponent
    {
        public LogicalOperator LogicalOperator { get; }
        public IEnumerable<IFilter> Filters { get; }

        public CompoundFilter(LogicalOperator logicalOperator, IEnumerable<IFilter> filters)
        {
            if (logicalOperator.IsSimpleOperator)
            {
                throw new ArgumentException($"A CompoundFilter cannot be created with simple logical operator [{logicalOperator.Name}].", nameof(logicalOperator));
            }

            LogicalOperator = logicalOperator;
            Filters = filters;
        }

        public override string ToString() => $"({LogicalOperator}{string.Join(string.Empty, Filters)})";
        public string ToDirectoryServicesString() => $"({LogicalOperator}{string.Join(string.Empty, Filters.Select(f => f.ToDirectoryServicesString()))})";
        public string ToLdapString() => $"({LogicalOperator}{string.Join(string.Empty, Filters.Select(f => f.ToLdapString()))})";
    }
}
