using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Separse
{
    public abstract class SExprEnumerable:  List<ISExpression>, ISExpression
    {
        public abstract Types Type { get; }
        public abstract string Value { get; }

        protected SExprEnumerable(IEnumerable<ISExpression> collection) : base(collection){}



        protected static ISExpression Convert(string s)
        {
            int ival;
            if (int.TryParse(s, out ival))
                return new SExprInteger(ival);
            float fval;
            if (float.TryParse(s.Replace('.',','), out fval))
                return new SExprFloat(fval);

            if (s.First() == '"' && s.Last() == '"')
                return new SExprString(s);

            if (s.First() == ':')
                return new SExprKeyword(s);

            if (s.First() == '(' && s.Last() == ')')
                return new SExprList(s);


            bool f = s.First() == '[';
            bool l = s.Last() == ']';
            if (s.First() == '[' && s.Last() == ']')
                return new SExprVector(s);

            if (Regex.IsMatch(s, @"^\d+"))
                throw new Exception("Symbol cannot start with numbers");
            
            return new SExprSymbol(s);

        }
        protected static IEnumerable<ISExpression> ConvertList(string s)
        =>IsEmptyCollection(s) ?  new ISExpression[]{}: SplitElements(s).Select(Convert) ;

        private static bool IsEmptyCollection(string s)
        {
            bool b = string.IsNullOrWhiteSpace(s.Substring(1, s.Length - 2));
            return b;
        }


        public static string[] SplitElements(string s)
        {
            s = s.Substring(1, s.Length - 2).Trim();

            var subElements = new List<string>();
            var builder = new StringBuilder();
            var depth = 0;
            bool inString = false;

            foreach (var chr in s)
            {


                if (chr == '"')
                    inString = !inString;
                if (!inString && (chr == '(' || chr == '['))
                    depth++;

                if(inString)
                    builder.Append(chr);
                else if(chr != ' ')
                    builder.Append(chr);


                if (!inString && (chr == ')' || chr == ']'))
                    depth--;

                if (depth == 0 && builder.Length != 0 && chr == ' ')
                {
                    subElements.Add(builder.ToString());
                    builder.Clear();
                }
            }
            subElements.Add(builder.ToString());
            builder.Clear();
            return subElements.ToArray();
        }


    }
}