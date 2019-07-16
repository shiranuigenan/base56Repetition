using System;

namespace base56Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            for (byte i = 0, j = 0; i < 255; i++, j *= 17)
                Console.WriteLine(++j);
        }
    }
}
