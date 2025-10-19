namespace Mittons.ActiveDirectory.Extensions
{
    public static class StringExtensions
    {
        public static string ToDirectoryServicesString(this string value)
            => value.Replace(@"\", @"\\")
                .Replace("*", @"\*")
                .Replace("(", @"\(")
                .Replace(")", @"\)");

        public static string ToLdapString(this string value)
            => value
                .Replace(@"\", @"\5c")
                .Replace("*", @"\2a")
                .Replace("(", @"\28")
                .Replace(")", @"\29")
                .Replace("\0", @"\00");
    }
}