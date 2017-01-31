using System.IO;
using System.Text;
using Separse;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Separser.Parse(new MemoryStream(Encoding.UTF8.GetBytes(
                "(1 2.3 \"3\" [ ] [] () (*) (asd?)   )")));

        }
    }
}
