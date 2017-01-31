using System.Globalization;

namespace Separse
{
    public class SExprFloat: ISExpression
    {

        private readonly double _val;
        public SExprFloat(double v)
        {
            _val = v;
        }
        public Types Type => Types.Float;
        public string Value => _val.ToString(CultureInfo.InvariantCulture);
    }
}