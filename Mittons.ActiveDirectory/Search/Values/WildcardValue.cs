using Mittons.ActiveDirectory.Extensions;

namespace Mittons.ActiveDirectory.Search.Values
{
    public class WildcardValue : IValue
    {
        public string Contents { get; }
        public bool IncludeStartWildcard { get; }
        public bool IncludeEndWildcard { get; }

        public string DefaultString
            => $"{(IncludeStartWildcard ? "*" : "")}{Contents}{(IncludeEndWildcard ? "*" : "")}";

        public string DirectoryServicesString
            => $"{(IncludeStartWildcard ? "*" : "")}{Contents.ToDirectoryServicesString()}{(IncludeEndWildcard ? "*" : "")}";

        public string LdapString
            => $"{(IncludeStartWildcard ? "*" : "")}{Contents.ToLdapString()}{(IncludeEndWildcard ? "*" : "")}";

        public WildcardValue(string contents, bool includeStartWildcard = false, bool includeEndWildcard = false)
        {
            Contents = contents;
            IncludeStartWildcard = includeStartWildcard;
            IncludeEndWildcard = includeEndWildcard;
        }
    }
}