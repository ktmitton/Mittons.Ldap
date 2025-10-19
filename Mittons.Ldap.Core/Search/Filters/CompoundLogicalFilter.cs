using System;
using System.Collections.Generic;
using System.Linq;
using Mittons.Ldap.Core.Search.Operators;

namespace Mittons.Ldap.Core.Search.Filters
{
    public class CompoundLogicalFilter : IFilterComponent
    {
        public LogicalOperator LogicalOperator { get; }
        public IEnumerable<IFilter> Filters { get; }

        public string DefaultString
            => $"({LogicalOperator.DefaultString}{string.Join(string.Empty, Filters.Select(f => f.DefaultString))})";

        public string DirectoryServicesString
            => $"({LogicalOperator.DirectoryServicesString}{string.Join(string.Empty, Filters.Select(f => f.DirectoryServicesString))})";

        public string LdapString
            => $"({LogicalOperator.LdapString}{string.Join(string.Empty, Filters.Select(f => f.LdapString))})";
        public CompoundLogicalFilter(LogicalOperator logicalOperator, IEnumerable<IFilter> filters)
        {
            if (logicalOperator.IsSimpleOperator)
            {
                throw new ArgumentException($"A CompoundFilter cannot be created with simple logical operator [{logicalOperator.Name}].", nameof(logicalOperator));
            }

            LogicalOperator = logicalOperator;
            Filters = filters;
        }
    }
}
