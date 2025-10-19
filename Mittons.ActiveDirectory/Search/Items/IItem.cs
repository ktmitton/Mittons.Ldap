namespace Mittons.ActiveDirectory.Search.Items
{
    public interface IItem
    {
        public string ToDirectoryServicesString();
        public string ToLdapString();
    }
}