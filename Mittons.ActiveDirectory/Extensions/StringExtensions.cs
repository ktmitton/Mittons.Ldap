namespace Mittons.ActiveDirectory.Extensions
{
    public static class StringExtensions
    {
        public static string ToLdapEscapedString(this string value)
            => value.Replace(@"\*", @"\2a")
                .Replace(@"\(", @"\28")
                .Replace(@"\)", @"\29")
                .Replace(@"\\", @"\5c");
    }
}