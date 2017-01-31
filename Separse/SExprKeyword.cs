namespace Separse
{
    public class SExprKeyword : ISExpression
    {
        public SExprKeyword(string value)
        {Value = value;}

        public Types Type => Types.Keyword;
        public string Value { get; }
    }
}