using System;
using Mittons.ActiveDirectory.Extensions;

namespace Mittons.ActiveDirectory.Search
{
    public class SimpleItem
    {
        public string Attribute { get; }
        public ComparisonOperator ComparisonOperator { get; }
        public string Value { get; }

        public SimpleItem(string attribute, ComparisonOperator comparisonOperator, string value)
        {
            if (string.IsNullOrWhiteSpace(attribute))
            {
                throw new ArgumentException("Attribute cannot be null, empty, or whitespace", nameof(attribute));
            }
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value cannot be null, empty, or whitespace", nameof(value));
            }

            Attribute = attribute;
            ComparisonOperator = comparisonOperator;
            Value = value;
        }

        public override string ToString()
            => $"({Attribute}{ComparisonOperator}{Value})";

        public string ToLdapEscapedString()
            => $"({Attribute.ToLdapEscapedString()}{ComparisonOperator}{Value.ToLdapEscapedString()})";
    }
}