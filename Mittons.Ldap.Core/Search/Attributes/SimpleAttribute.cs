namespace Mittons.Ldap.Core.Search.Attributes
{
    public class SimpleAttribute : IAttribute
    {
        public string Contents { get; }

        public SimpleAttribute(string contents)
        {
            Contents = contents;
        }

        public string DefaultString => Contents;

        public string DirectoryServicesString => Contents;

        public string LdapString => Contents;
    }
}