using System;

namespace HelloWorldApplication
{
	class HelloWorld
	{
		static void Main(string[] args)
		{
			// {0} is a kind of string format, where 0 indicates the index of object. `sizeof(int)` is {0} in the line below
			// while "haha" is the {1} 
			Console.WriteLine("Hello World {0}, {0:C2}, {1}", sizeof(int), "haha");
			// read a key from standard input
			Console.ReadKey();
		}
	}
}
