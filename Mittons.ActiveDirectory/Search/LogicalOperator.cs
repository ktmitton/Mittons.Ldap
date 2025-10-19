namespace Mittons.ActiveDirectory.Search
{
    public class LogicalOperator
    {
        public static readonly LogicalOperator And = new LogicalOperator("And", "&", false);
        public static readonly LogicalOperator Or = new LogicalOperator("Or", "|", false);
        public static readonly LogicalOperator Not = new LogicalOperator("Not", "!", true);

        public string Name { get; }
        public string StringLiteral { get; }
        public bool IsSimpleOperator { get; }
        public bool IsCompoundOperator => !IsSimpleOperator;

        private LogicalOperator(string name, string stringLiteral, bool isSimpleOperator)
        {
            Name = name;
            StringLiteral = stringLiteral;
            IsSimpleOperator = isSimpleOperator;
        }

        public override string ToString() => StringLiteral;
    }
}