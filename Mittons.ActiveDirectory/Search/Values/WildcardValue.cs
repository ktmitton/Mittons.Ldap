using Mittons.ActiveDirectory.Extensions;

namespace Mittons.ActiveDirectory.Search.Values
{
    public class WildcardValue
    {
        public string Contents { get; }
        public bool IncludeStartWildcard { get; }
        public bool IncludeEndWildcard { get; }

        public WildcardValue(string contents, bool includeStartWildcard = false, bool includeEndWildcard = false)
        {
            Contents = contents;
            IncludeStartWildcard = includeStartWildcard;
            IncludeEndWildcard = includeEndWildcard;
        }

        public override string ToString()
            => $"{(IncludeStartWildcard ? "*" : "")}{Contents}{(IncludeEndWildcard ? "*" : "")}";

        public string ToDirectoryServicesString()
            => $"{(IncludeStartWildcard ? "*" : "")}{Contents.ToDirectoryServicesString()}{(IncludeEndWildcard ? "*" : "")}";

        public string ToLdapString()
            => $"{(IncludeStartWildcard ? "*" : "")}{Contents.ToLdapString()}{(IncludeEndWildcard ? "*" : "")}";
    }
}