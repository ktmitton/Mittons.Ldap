using Mittons.Ldap.Core.Search.Attributes;
using Mittons.Ldap.Core.Search.Operators;
using Mittons.Ldap.Core.Search.Values;

namespace Mittons.Ldap.Core.Search.Filters
{
    public class SimpleItemFilter : IFilterComponent
    {
        public SimpleAttribute Attribute { get; }
        public ComparisonOperator ComparisonOperator { get; }
        public IValue Value { get; }

        public string DefaultString
            => $"({Attribute.DefaultString}{ComparisonOperator.DefaultString}{Value.DefaultString})";

        public string DirectoryServicesString
            => $"({Attribute.DirectoryServicesString}{ComparisonOperator.DirectoryServicesString}{Value.DirectoryServicesString})";

        public string LdapString
            => $"({Attribute.LdapString}{ComparisonOperator.LdapString}{Value.LdapString})";

        public SimpleItemFilter(SimpleAttribute attribute, ComparisonOperator comparisonOperator, IValue value)
        {
            Attribute = attribute;
            ComparisonOperator = comparisonOperator;
            Value = value;
        }
    }
}