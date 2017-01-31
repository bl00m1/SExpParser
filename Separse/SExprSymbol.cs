namespace Separse
{
    public class SExprSymbol : ISExpression
    {
        public SExprSymbol(string value)
        {
            Value = value;
        }

        public Types Type => Types.Symbol;
        public string Value { get; }
    }
}