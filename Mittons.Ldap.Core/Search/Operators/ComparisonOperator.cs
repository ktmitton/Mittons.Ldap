namespace Mittons.Ldap.Core.Search.Operators
{
    public class ComparisonOperator : ISearchComponent
    {
        public static readonly ComparisonOperator Equality = new ComparisonOperator("Equality", "=");
        public static readonly ComparisonOperator ApproximateMatch = new ComparisonOperator("ApproximateMatch", "~=");
        public static readonly ComparisonOperator GreaterThanOrEqual = new ComparisonOperator("GreaterThanOrEqual", ">=");
        public static readonly ComparisonOperator LessThanOrEqual = new ComparisonOperator("LessThanOrEqual", "<=");

        public string Name { get; }
        public string StringLiteral { get; }

        public string DefaultString => StringLiteral;

        public string DirectoryServicesString => StringLiteral;

        public string LdapString => StringLiteral;

        private ComparisonOperator(string name, string stringLiteral)
        {
            Name = name;
            StringLiteral = stringLiteral;
        }

        public override string ToString() => Name;
    }
}