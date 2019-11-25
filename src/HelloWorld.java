public class HelloWorld {
    String x;
    public HelloWorld(String input)
    {
        System.out.println("new object created with input = "+input);
        x = input;
    }
    public void setX(String input)
    {
        x = input;
    }
    public String getX()
    {
        return x;
    }
    public static void main(String[] args)
    {
        HelloWorld myWorld = new HelloWorld("haha");
        if(args.length>0)
        {
            myWorld.setX(args[0]);
            System.out.println(myWorld.getX());
        }
        else
        {
            System.out.println("an argument is required!");
        }
    }
}
