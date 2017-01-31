using System.IO;

namespace Separse
{
    static class Helpers
    {
        public static bool IsAtEnd(this Stream stream)
            => stream.Length == stream.Position;


        
    }

}
