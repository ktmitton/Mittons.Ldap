namespace Mittons.ActiveDirectory.Search.Attributes
{
    public class SimpleAttribute
    {
        public string Contents { get; }

        public SimpleAttribute(string contents)
        {
            Contents = contents;
        }

        public override string ToString() => Contents;

        public string ToDirectoryServicesString() => ToString();

        public string ToLdapString() => ToString();
    }
}