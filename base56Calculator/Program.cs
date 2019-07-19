using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace base56Calculator
{
    class Program
    {
        public const int bufferSize = 33554432;//32M
        static void Main(string[] args)
        {
            try
            {
                var importPath = args[0];
                var files = Directory.GetFiles(importPath).OrderBy(x => x).ToArray();

                // var result1 = new int[56];
                // var result2 = new int[3136];
                // var result3 = new int[175616];
                // var result4 = new short[9834496];
                // var result5 = new byte[550731776];
                var result6 = new byte[2000000000];
                

                var buffer = new byte[bufferSize];
                foreach (var file in files)
                {
                    using (var f = File.OpenRead(file))
                    {
                        var bytesRead = 0;
                        while ((bytesRead = f.Read(buffer, 0, bufferSize)) > 0)
                            for (int i = 0; i < bytesRead; i += 16)
                            {
                                var j = BitConverter.ToUInt32(buffer, i);
                                // result1[j % 56]++;
                                // result2[j % 3136]++;
                                // result3[j % 175616]++;
                                // result4[j % 9834496]++;
                                // result5[j % 550731776]++;
                                result6[j % 2000000000]++;
                            }
                    }
                }
                var s = new List<string>();
                // s.Add("max 1 " + result1.Max());
                // s.Add("min 1 " + result1.Min());
                // s.Add("avg 1 " + result1.Average());
                // s.Add("max 2 " + result2.Max());
                // s.Add("min 2 " + result2.Min());
                // s.Add("avg 2 " + result2.Average());
                // s.Add("max 3 " + result3.Max());
                // s.Add("min 3 " + result3.Min());
                // s.Add("avg 3 " + result3.Average());
                // s.Add("max 4 " + result4.Max());
                // s.Add("min 4 " + result4.Min());
                // s.Add("avg 4 " + result4.Average());
                // s.Add("max 5 " + result5.Max());
                // s.Add("min 5 " + result5.Min());
                // s.Add("avg 5 " + result5.Average());
                s.Add("max 6 " + result6.Max());
                s.Add("min 6 " + result6.Min());
                s.Add("avg 6 " + result6.Average(x=>(double)x));
                
                File.WriteAllLines("result2.txt", s);

            }
            catch (System.Exception) { }
        }
    }
}
