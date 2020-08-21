import java.util.*;
// a demonstration for simple constructor

class Rock
{
	int r;
	Rock()
	{
		System.out.println("Rock: ");
	}
	Rock(int r) 
	{
		// unlike C++, there is no pointer in Java
		// thus, we can use this.r instead of this->r
		this.r = r;
		System.out.printf("Rock: %d\n",this.r);
	}
	int getR()
	{
		return r;	
	}
}

public class SimpleConstructor
{
	public static void main(String []args)
	{
		for(int i=0;i<10;i++)
		{
			Rock R = new Rock(i);
			System.out.println(R.getR());
		}
	}
}
