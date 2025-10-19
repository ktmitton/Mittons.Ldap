namespace Mittons.ActiveDirectory.Search.Filters
{
    public interface IFilter
    {
        public string ToDirectoryServicesString();
        public string ToLdapString();
    }
}