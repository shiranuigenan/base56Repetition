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
                for (var i = 10; i < 100; i++)
                {
                    try
                    {
                        var p = new Process { StartInfo = { FileName = "base56Generator" } };
                        p.StartInfo.Arguments = exportPath + i + ".bin " + (guidMultiplier * ((int)(i*1.5281)));
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
