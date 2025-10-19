using Mittons.ActiveDirectory.Extensions;

namespace Mittons.ActiveDirectory.Search.Values
{
    public class SimpleValue
    {
        public string Contents { get; }

        public SimpleValue(string contents)
        {
            Contents = contents;
        }

        public override string ToString() => Contents;

        public string ToDirectoryServicesString() => Contents.ToDirectoryServicesString();

        public string ToLdapString() => Contents.ToLdapString();
    }
}