using System;
using System.IO;

namespace base56Generator
{
    class Program
    {
        public const int guidBufferCount = 2097152;
        static void Main(string[] args)
        {
            try
            {
                var fileName = args[0];
                var totalGuidCount = Convert.ToInt32(args[1]);

                using (var f = File.OpenWrite(fileName))
                {
                    var buffer = new byte[guidBufferCount * 16];
                    var remainGuidCount = totalGuidCount;
                    do
                    {
                        var writingGuidCount = Math.Min(guidBufferCount, remainGuidCount);

                        for (int i = 0; i < writingGuidCount; i++)
                            Array.Copy(Guid.NewGuid().ToByteArray(), 0, buffer, 16 * i, 16);

                        f.Write(buffer, 0, writingGuidCount * 16);

                        //Console.WriteLine(writingGuidCount);
                        remainGuidCount -= writingGuidCount;

                    } while (remainGuidCount > 0);
                }
            }
            catch (System.Exception) { }
        }
    }
}
