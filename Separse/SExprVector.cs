using System.Collections.Generic;
using System.Linq;

namespace Separse
{
    public class SExprVector : SExprEnumerable
    {
        public SExprVector(IEnumerable<ISExpression> collection) : base(collection)
        {}

        public SExprVector(string s) : base(ConvertList(s)) { }



        public override Types Type => Types.Vector;
        public override string Value => "[" + string.Join(" ", this.Select(se => se.Value)) + "]";
    }
}