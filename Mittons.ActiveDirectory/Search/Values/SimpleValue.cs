using Mittons.ActiveDirectory.Extensions;

namespace Mittons.ActiveDirectory.Search.Values
{
    public class SimpleValue : IValue
    {
        public string Contents { get; }

        public string DefaultString
            => Contents;

        public string DirectoryServicesString
            => Contents.ToDirectoryServicesString();

        public string LdapString
            => Contents.ToLdapString();

        public SimpleValue(string contents)
        {
            Contents = contents;
        }
    }
}