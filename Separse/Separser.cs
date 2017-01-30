using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Separse
{
    public static class Separser
    {
        public static ISExpression[] Parse(Stream input)
        {
            var tokens = SplitByTokens(input, '(', ')');
            tokens.Select(Parse);
            return null;
        }

        public static ISExpression[] Parse(string s)
        {
            return null;
        }

        public static List<string> SplitByTokens(this Stream stream, char beginToken, char endToken)
        {
            var bstream = new BinaryReader(stream, Encoding.UTF8);
            var depth = 0;
            var tokens = new List<string>();
            var builder = new StringBuilder();
            while (!bstream.BaseStream.IsAtEnd())
            {
                var inString = false;
                builder.Clear();
                do
                {
                    var chr = bstream.ReadChar();

                    if (chr == '"')
                        inString = !inString;
                    if (!inString && chr == beginToken)
                        depth++;
                    if (depth > 0)
                        builder.Append(chr);

                    if (!inString && chr == endToken)
                        depth--;

                } while (depth > 0);
                if (builder.Length != 0)
                    tokens.Add(builder.ToString());

            }
            return tokens;
        }

    }

}
