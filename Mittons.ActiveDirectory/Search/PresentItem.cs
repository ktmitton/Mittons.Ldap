namespace Mittons.ActiveDirectory.Search
{
    public class PresentItem
    {
        public Attribute Attribute { get; }

        public PresentItem(Attribute attribute)
        {
            Attribute = attribute;
        }

        public override string ToString() => $"({Attribute}=*)";

        public string ToDirectoryServicesString() => $"({Attribute.ToDirectoryServicesString()}=*)";

        public string ToLdapString() => $"({Attribute.ToLdapString()}=*)";
    }
}