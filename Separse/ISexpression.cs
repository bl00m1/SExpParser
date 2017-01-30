using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Separse
{
    public interface ISExpression
    {
        Types Type { get; }
        string Value { get; }
    }

    public enum Types :byte
    {
        List,Vector,Symbol,Keyword,Integer,Float,String,
    }

    abstract class SExprEnumerable:  List<ISExpression>, ISExpression
    {
        public abstract Types Type { get; }
        public abstract string Value { get; }

        protected SExprEnumerable(IEnumerable<ISExpression> collection) : base(collection){}
    }

    class SExprList : SExprEnumerable
    {
        public SExprList(IEnumerable<ISExpression> collection) : base(collection)
        {}

        public override Types Type => Types.List;
        public override string Value => "(" + string.Join(" ", this.Select(se => se.Value)) + ")";

    }

    class SExprVector : SExprEnumerable
    {
        public SExprVector(IEnumerable<ISExpression> collection) : base(collection)
        {}

        public override Types Type => Types.Vector;
        public override string Value => "[" + string.Join(" ", this.Select(se => se.Value)) + "]";
    }

    class SExprSymbol : ISExpression
    {
        public SExprSymbol(string value)
        {
            Value = value;
        }

        public Types Type => Types.Symbol;
        public string Value { get; }
    }

    class SExprString : ISExpression
    {
        public SExprString(string value)
        {
            Value = value;
        }

        public Types Type => Types.String;
        public string Value { get; }
    }
    class SExprKeyword : ISExpression
    {
        public SExprKeyword(string value)
        {Value = value;}

        public Types Type => Types.Keyword;
        public string Value { get; }
    }

    class SExprInteger : ISExpression
    {

        private readonly int _val;
        public SExprInteger(int v)
        {
            _val = v;
        }
        public Types Type => Types.Integer;
        public string Value => _val.ToString();
    }
    class SExprFloat: ISExpression
    {

        private readonly float _val;
        public SExprFloat(float v)
        {
            _val = v;
        }
        public Types Type => Types.Float;
        public string Value => _val.ToString(CultureInfo.InvariantCulture);
    }
}
