namespace Mittons.Ldap.Core.Search.Operators
{
    public class LogicalOperator : ISearchComponent
    {
        public static readonly LogicalOperator And = new LogicalOperator("And", "&", false);
        public static readonly LogicalOperator Or = new LogicalOperator("Or", "|", false);
        public static readonly LogicalOperator Not = new LogicalOperator("Not", "!", true);

        public string Name { get; }
        public string StringLiteral { get; }
        public bool IsSimpleOperator { get; }
        public bool IsCompoundOperator => !IsSimpleOperator;

        public string DefaultString => StringLiteral;

        public string DirectoryServicesString => StringLiteral;

        public string LdapString => StringLiteral;

        private LogicalOperator(string name, string stringLiteral, bool isSimpleOperator)
        {
            Name = name;
            StringLiteral = stringLiteral;
            IsSimpleOperator = isSimpleOperator;
        }

        public override string ToString() => Name;
    }
}