using Mittons.Ldap.Core.Search.Attributes;

namespace Mittons.Ldap.Core.Search.Filters
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