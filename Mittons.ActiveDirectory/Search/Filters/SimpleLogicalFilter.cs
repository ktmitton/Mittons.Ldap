using System;
using Mittons.ActiveDirectory.Search.Operators;

namespace Mittons.ActiveDirectory.Search.Filters
{
    public class SimpleLogicalFilter : IFilterComponent
    {
        public LogicalOperator LogicalOperator { get; }
        public IFilter Filter { get; }

        public string DefaultString
            => $"({LogicalOperator.DefaultString}{Filter.DefaultString})";

        public string DirectoryServicesString
            => $"({LogicalOperator.DirectoryServicesString}{Filter.DirectoryServicesString})";

        public string LdapString
            => $"({LogicalOperator.LdapString}{Filter.LdapString})";

        public SimpleLogicalFilter(LogicalOperator logicalOperator, IFilter filter)
        {
            if (logicalOperator.IsCompoundOperator)
            {
                throw new ArgumentException($"A SimpleFilter cannot be created with compound logical operator [{logicalOperator.Name}].", nameof(logicalOperator));
            }

            LogicalOperator = logicalOperator;
            Filter = filter;
        }
    }
}
