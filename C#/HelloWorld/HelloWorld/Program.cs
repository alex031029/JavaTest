using System;

namespace HelloWorldApplication
{
	class HelloWorld
	{
		// VS suggests me to an upper case in a method
		public void Swap(ref int x, ref int y)
		{
			int temp = x;
			x = y;
			y = temp;
		}	
		static void Main(string[] args)
		{
			// {0} is a kind of string format, where 0 indicates the index of object. `sizeof(int)` is {0} in the line below
			// while String s is the {1} 
			// @ is to omit escape operator \
			String s = @"C:\Windows";
			Console.WriteLine("Hello World {0}, {0:C2}, {1}", sizeof(int), s);

			int a = 10;
			int b = 100;

			// as an OO language, an object has to be initialzed in order to invoke a method
			HelloWorld h = new HelloWorld();
			h.Swap(ref a, ref b);
			Console.WriteLine("a:{0}, b:{1}", a, b);
			// read a key from standard input
			Console.ReadKey();
		}
	}
}
