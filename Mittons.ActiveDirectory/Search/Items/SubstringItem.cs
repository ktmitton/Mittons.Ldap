using Mittons.ActiveDirectory.Search.Attributes;
using Mittons.ActiveDirectory.Search.Values;

namespace Mittons.ActiveDirectory.Search.Items
{
    public class SubstringItem : IItem
    {
        public SimpleAttribute Attribute { get; set; }
        public SimpleValue? StartValue { get; set; }
        public WildcardValue Value { get; set; }
        public SimpleValue? EndValue { get; set; }

        public SubstringItem(SimpleAttribute attribute, SimpleValue? startValue, WildcardValue value, SimpleValue? endValue)
        {
            Attribute = attribute;
            StartValue = startValue;
            Value = value;
            EndValue = endValue;
        }

        public override string ToString()
            => $"({Attribute}={StartValue}{Value}{EndValue})";

        public string ToDirectoryServicesString()
            => $"({Attribute.ToDirectoryServicesString()}={StartValue?.ToDirectoryServicesString()}{Value.ToDirectoryServicesString()}{EndValue?.ToDirectoryServicesString()})";

        public string ToLdapString()
            => $"({Attribute.ToLdapString()}={StartValue?.ToLdapString()}{Value.ToLdapString()}{EndValue?.ToLdapString()})";
    }
}