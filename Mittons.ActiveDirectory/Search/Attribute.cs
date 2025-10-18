namespace Mittons.ActiveDirectory.Search
{
    public class Attribute
    {
        public string Contents { get; }

        public Attribute(string contents)
        {
            Contents = contents;
        }

        public override string ToString() => Contents;

        public string ToDirectoryServicesString() => ToString();

        public string ToLdapString() => ToString();
    }
}