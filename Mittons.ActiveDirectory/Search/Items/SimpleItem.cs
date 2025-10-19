using Mittons.ActiveDirectory.Search.Values;

namespace Mittons.ActiveDirectory.Search.Items
{
    public class SimpleItem
    {
        public Attribute Attribute { get; }
        public ComparisonOperator ComparisonOperator { get; }
        public SimpleValue Value { get; }

        public SimpleItem(string attribute, ComparisonOperator comparisonOperator, string contents)
            : this(new Attribute(attribute), comparisonOperator, new SimpleValue(contents))
        {
        }

        public SimpleItem(Attribute attribute, ComparisonOperator comparisonOperator, SimpleValue value)
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