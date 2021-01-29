using System;

namespace SeperateMailAddress
{
    class Program
    {
        static void Main(string[] args)
        {
            // the exe file is in bin/Debug/netcoreapp3.1/ folder
            // NB: I should write a try here
            // both ../../../ and ./ should be tried
            var text = System.IO.File.ReadAllLines(@"../../../test.input");
            System.Console.WriteLine(text[0]);
        }
    }
}
