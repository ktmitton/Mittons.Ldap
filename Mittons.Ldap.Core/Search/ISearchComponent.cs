namespace Mittons.Ldap.Core.Search
{
    public interface ISearchComponent
    {
        public string DefaultString { get; }
        public string DirectoryServicesString { get; }
        public string LdapString { get; }
    }
}