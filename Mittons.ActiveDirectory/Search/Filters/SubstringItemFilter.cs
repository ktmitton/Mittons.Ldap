using Mittons.ActiveDirectory.Search.Attributes;
using Mittons.ActiveDirectory.Search.Values;

namespace Mittons.ActiveDirectory.Search.Filters
{
    public class SubstringItemFilter : IFilterComponent
    {
        public SimpleAttribute Attribute { get; set; }
        public SimpleValue? StartValue { get; set; }
        public WildcardValue Value { get; set; }
        public SimpleValue? EndValue { get; set; }

        public string DefaultString
            => $"({Attribute.DefaultString}={StartValue?.DefaultString}{Value.DefaultString}{EndValue?.DefaultString})";

        public string DirectoryServicesString
            => $"({Attribute.DirectoryServicesString}={StartValue?.DirectoryServicesString}{Value.DirectoryServicesString}{EndValue?.DirectoryServicesString})";

        public string LdapString
            => $"({Attribute.LdapString}={StartValue?.LdapString}{Value.LdapString}{EndValue?.LdapString})";

        public SubstringItemFilter(SimpleAttribute attribute, SimpleValue? startValue, WildcardValue value, SimpleValue? endValue)
        {
            Attribute = attribute;
            StartValue = startValue;
            Value = value;
            EndValue = endValue;
        }
    }
}