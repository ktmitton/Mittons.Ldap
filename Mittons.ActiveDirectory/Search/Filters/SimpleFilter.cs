using System;
using Mittons.ActiveDirectory.Search.Operators;

namespace Mittons.ActiveDirectory.Search.Filters
{
    public class SimpleFilter : IFilterComponent
    {
        public LogicalOperator LogicalOperator { get; }
        public IFilter Filter { get; }

        public SimpleFilter(LogicalOperator logicalOperator, IFilter filter)
        {
            if (logicalOperator.IsCompoundOperator)
            {
                throw new ArgumentException($"A SimpleFilter cannot be created with compound logical operator [{logicalOperator.Name}].", nameof(logicalOperator));
            }

            LogicalOperator = logicalOperator;
            Filter = filter;
        }

        public override string ToString() => $"({LogicalOperator}{Filter})";
        public string ToDirectoryServicesString() => $"({LogicalOperator}{Filter.ToDirectoryServicesString()})";
        public string ToLdapString() => $"({LogicalOperator}{Filter.ToLdapString()})";
    }
}
