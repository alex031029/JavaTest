using System;
using System.Threading.Tasks.Dataflow;

namespace SeperateMailAddress
{
    class Program
    {
        static void Main(string[] args)
        {
            // the exe file is in bin/Debug/netcoreapp3.1/ folder
            // NB: I should write a try here
            // both ../../../ and ./ should be tried
            string[] text = new string[200];
            try
            {
                text = System.IO.File.ReadAllLines(@"../../../input.txt");
            }
            catch(Exception ex1)
            {
                try
                {
                    text = System.IO.File.ReadAllLines(@"input.txt");
                }
                catch(Exception ex2)
                {
                    System.Console.WriteLine("Please put the input file along with this exe file");
                    System.Console.WriteLine(ex1);
                    System.Console.WriteLine(ex2);
                }
            }
            string output = String.Join(";", text);
            System.IO.File.WriteAllText("output.txt", output);
        }
    }
}
