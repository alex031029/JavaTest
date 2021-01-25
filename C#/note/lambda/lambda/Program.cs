using System;

namespace lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            int offset = 2;
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5));       // 25

            Func<int, int> square2 = x =>
            {
                x += offset;
                offset = 3;
                return x * x;
            };
            Console.WriteLine("offset is {0}", offset);  // offset is still 2
            Console.WriteLine(square2(5));      // 49

            // Action, indicating no return value
            Action<string> print = name => Console.WriteLine(name);
            print("yansh");

            // more than parameters
            // we can also explictly write down the input type
            Func<int, int, int> add = (int x, int y) => x + y;
            Console.WriteLine(add(1, 2));
        }
    }
}
