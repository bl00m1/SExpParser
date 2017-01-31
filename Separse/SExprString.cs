namespace Separse
{
    public class SExprString : ISExpression
    {
        public SExprString(string value)
        {
            Value = value;
        }

        public Types Type => Types.String;
        public string Value { get; }
    }
}