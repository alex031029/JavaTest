public class HelloWorld {
    public static void main(String[] args)
    {
        Foo myFoo = new Foo("haha");
        if(args.length>0)
        {
            myFoo.setName(args[0]);
            System.out.println(myFoo.getName());
        }
        else
        {
            System.out.println("an argument is required!");
        }
    }
}
