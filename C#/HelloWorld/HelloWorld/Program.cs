using System;

namespace HelloWorldApplication
{
	class HelloWorld
	{
		static void Main(string[] args)
		{
			// {0} is a kind of string format, where 0 indicates the index of object. `sizeof(int)` is {0} in the line below
			// while String s is the {1} 
			// @ is to omit escape operator \
			String s = @"C:\Windows";
			Console.WriteLine("Hello World {0}, {0:C2}, {1}", sizeof(int), s);
			// read a key from standard input
			Console.ReadKey();
		}
	}
}
