using System;
using System.IO;

namespace base56Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var fileName = args[0];
                var guidCount = Convert.ToInt32(args[1]);

                var bytes = new byte[guidCount * 16];
                for (int i = 0; i < guidCount; i++)
                    Array.Copy(Guid.NewGuid().ToByteArray(), 0, bytes, 16 * i, 16);

                File.WriteAllBytes(fileName, bytes);
            }
            catch (System.Exception) { }
        }
    }
}
