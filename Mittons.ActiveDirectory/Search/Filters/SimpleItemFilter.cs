using Mittons.ActiveDirectory.Search.Attributes;
using Mittons.ActiveDirectory.Search.Operators;
using Mittons.ActiveDirectory.Search.Values;

namespace Mittons.ActiveDirectory.Search.Filters
{
    public class SimpleItemFilter : IFilterComponent
    {
        public SimpleAttribute Attribute { get; }
        public ComparisonOperator ComparisonOperator { get; }
        public SimpleValue Value { get; }

        public SimpleItemFilter(string attribute, ComparisonOperator comparisonOperator, string contents)
            : this(new SimpleAttribute(attribute), comparisonOperator, new SimpleValue(contents))
        {
        }

        public SimpleItemFilter(SimpleAttribute attribute, ComparisonOperator comparisonOperator, SimpleValue value)
        {
            Attribute = attribute;
            ComparisonOperator = comparisonOperator;
            Value = value;
        }

        public override string ToString()
            => $"({Attribute}{ComparisonOperator}{Value})";

        public string ToDirectoryServicesString()
            => $"({Attribute}{ComparisonOperator}{Value.ToDirectoryServicesString()})";

        public string ToLdapString()
            => $"({Attribute}{ComparisonOperator}{Value.ToLdapString()})";
    }
}