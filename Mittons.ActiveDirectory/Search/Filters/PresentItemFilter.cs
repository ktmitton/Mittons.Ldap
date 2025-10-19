using Mittons.ActiveDirectory.Search.Attributes;

namespace Mittons.ActiveDirectory.Search.Filters
{
    public class PresentItemFilter : IFilterComponent
    {
        public SimpleAttribute Attribute { get; }

        public string DefaultString
            => $"({Attribute.DefaultString}=*)";

        public string DirectoryServicesString
            => $"({Attribute.DirectoryServicesString}=*)";

        public string LdapString
            => $"({Attribute.LdapString}=*)";

        public PresentItemFilter(SimpleAttribute attribute)
        {
            Attribute = attribute;
        }
    }
}