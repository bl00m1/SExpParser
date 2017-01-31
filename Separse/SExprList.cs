using System.Collections.Generic;
using System.Linq;

namespace Separse
{
    public class SExprList : SExprEnumerable
    {
        public SExprList(IEnumerable<ISExpression> collection) : base(collection)
        {}

        public SExprList(string s) : base(ConvertList(s)) { }


        public override Types Type => Types.List;
        public override string Value => "(" + string.Join(" ", this.Select(se => se.Value)) + ")";

    }
}