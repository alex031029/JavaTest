import java.util.*;
// a demonstration for simple constructor

class Rock
{
	Rock()
	{
		System.out.println("Rock: ");
	}
	Rock(int i)
	{
		System.out.printf("Rock: %d\n",i);
	}
}

public class SimpleConstructor
{
	public static void main(String []args)
	{
		for(int i=0;i<10;i++)
		{
			new Rock(i);
		}
	}
}
