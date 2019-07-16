using System;
using System.Diagnostics;

namespace base56Repetition
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var exportPath = args[0];
                var guidMultiplier = Convert.ToInt32(args[1]);
                for (byte i = 0, j = 0; i < 232; i++, j *= 17)
                {
                    j++;
                    if (j == 100) continue;
                    try
                    {
                        var p = new Process { StartInfo = { FileName = "base56Generator" } };
                        p.StartInfo.Arguments = exportPath + i.ToString("D3") + ".bin " + (guidMultiplier * j);
                        p.Start();
                        p.PriorityClass = ProcessPriorityClass.BelowNormal;

                    }
                    catch (System.Exception) { }
                }
            }
            catch (System.Exception) { }
        }
    }
}
