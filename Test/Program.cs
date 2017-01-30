using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Separse;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Separser.Parse(new MemoryStream(Encoding.UTF8.GetBytes(
                "(1 2.3 \"3\" (four :five [six ]))    (seven ) (eight [nine 10])")));

        }
    }
}
