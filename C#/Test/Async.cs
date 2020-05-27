using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PoolCreation
{
    class Program
    {
        internal static async Task TestAsync()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("TestAsync");
            });
            Console.WriteLine("TestSync");
            return;
        }

        // async Task Main is supported after C# 7.1
        // VS 2017 would raise an error if we do not modify .csproj file
        // VS 2019 could successfully compile the file
        static async Task Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            
            Console.WriteLine("Hello World!");
            await TestAsync();
            Console.WriteLine("Good Bye");
            Console.ReadKey();
            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
