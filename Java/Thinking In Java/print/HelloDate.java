// HelloDate.java

import java.util.*;

public class HelloDate 
{
	// do not forget to capitalize S in string 
	public static void main(String[] args)
	{
		int n = 10;
		// unlike golang, println does not capitalized 
		System.out.println("Hello, it is  ");		
		System.out.println(new Date());
		System.out.print("no new line print");
		System.out.printf("format print %d\n", n);
	}
}
