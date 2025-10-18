using System;
using Mittons.ActiveDirectory.Extensions;

namespace Mittons.ActiveDirectory.Search
{
    public class PresentItem
    {
        public string Attribute { get; }

        public PresentItem(string attribute)
        {
            if (string.IsNullOrWhiteSpace(attribute))
            {
                throw new ArgumentException("Attribute cannot be null, empty, or whitespace", nameof(attribute));
            }

            Attribute = attribute;
        }

        public override string ToString()
            => $"({Attribute}=*)";

        public string ToLdapEscapedString()
            => $"({Attribute.ToLdapEscapedString()}=*)";
    }
}