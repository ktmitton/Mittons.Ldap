using Mittons.ActiveDirectory.Search.Attributes;
using Mittons.ActiveDirectory.Search.Operators;
using Mittons.ActiveDirectory.Search.Values;

namespace Mittons.ActiveDirectory.Search.Filters
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

        public SimpleItemFilter(string attribute, ComparisonOperator comparisonOperator, string contents)
            : this(new SimpleAttribute(attribute), comparisonOperator, new SimpleValue(contents))
        {
        }

        public SimpleItemFilter(SimpleAttribute attribute, ComparisonOperator comparisonOperator, IValue value)
        {
            Attribute = attribute;
            ComparisonOperator = comparisonOperator;
            Value = value;
        }
    }
}