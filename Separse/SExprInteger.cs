namespace Separse
{
    public class SExprInteger : ISExpression
    {

        private readonly int _val;
        public SExprInteger(int v)
        {
            _val = v;
        }
        public Types Type => Types.Integer;
        public string Value => _val.ToString();
    }
}