namespace Mittons.ActiveDirectory.Search
{
    public class SimpleItem
    {
        public Attribute Attribute { get; }
        public ComparisonOperator ComparisonOperator { get; }
        public Value Value { get; }

        public SimpleItem(string attribute, ComparisonOperator comparisonOperator, string contents)
            : this(new Attribute(attribute), comparisonOperator, new Value(contents))
        {
        }

        public SimpleItem(Attribute attribute, ComparisonOperator comparisonOperator, Value value)
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