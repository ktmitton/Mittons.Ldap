using Mittons.ActiveDirectory.Search.Attributes;

namespace Mittons.ActiveDirectory.Search.Filters
{
    public class PresentItemFilter : IFilterComponent
    {
        public SimpleAttribute Attribute { get; }

        public PresentItemFilter(SimpleAttribute attribute)
        {
            Attribute = attribute;
        }

        public override string ToString() => $"({Attribute}=*)";

        public string ToDirectoryServicesString() => $"({Attribute.ToDirectoryServicesString()}=*)";

        public string ToLdapString() => $"({Attribute.ToLdapString()}=*)";
    }
}