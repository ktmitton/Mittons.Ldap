namespace Mittons.ActiveDirectory.Search.Operators
{
    public class ComparisonOperator
    {
        public static readonly ComparisonOperator Equality = new ComparisonOperator("Equality", "=");
        public static readonly ComparisonOperator ApproximateMatch = new ComparisonOperator("ApproximateMatch", "~=");
        public static readonly ComparisonOperator GreaterThanOrEqual = new ComparisonOperator("GreaterThanOrEqual", ">=");
        public static readonly ComparisonOperator LessThanOrEqual = new ComparisonOperator("LessThanOrEqual", "<=");

        public string Name { get; }
        public string StringLiteral { get; }

        private ComparisonOperator(string name, string stringLiteral)
        {
            Name = name;
            StringLiteral = stringLiteral;
        }

        public override string ToString() => StringLiteral;
    }
}