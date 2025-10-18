namespace Mittons.ActiveDirectory.Search
{
    public class Value
    {
        public string Contents { get; }

        public Value(string contents)
        {
            Contents = contents;
        }

        public override string ToString() => Contents;

        public string ToDirectoryServicesString()
            => Contents
                .Replace(@"\", @"\\")
                .Replace("*", @"\*")
                .Replace("(", @"\(")
                .Replace(")", @"\)");

        public string ToLdapString()
            => Contents
                .Replace(@"\", @"\5c")
                .Replace("*", @"\2a")
                .Replace("(", @"\28")
                .Replace(")", @"\29")
                .Replace("\0", @"\00");
    }
}