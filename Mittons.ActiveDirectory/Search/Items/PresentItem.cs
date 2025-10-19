using Mittons.ActiveDirectory.Search.Attributes;

namespace Mittons.ActiveDirectory.Search.Items
{
    public class PresentItem : IItem
    {
        public SimpleAttribute Attribute { get; }

        public PresentItem(SimpleAttribute attribute)
        {
            Attribute = attribute;
        }

        public override string ToString() => $"({Attribute}=*)";

        public string ToDirectoryServicesString() => $"({Attribute.ToDirectoryServicesString()}=*)";

        public string ToLdapString() => $"({Attribute.ToLdapString()}=*)";
    }
}