using Mittons.Ldap.Core.Extensions;

namespace Mittons.Ldap.Core.Search.Values
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