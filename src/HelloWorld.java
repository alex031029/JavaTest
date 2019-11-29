public class HelloWorld {
    public static void main(String[] args)
    {
        Foo myFoo = new Foo("");
        if(args.length>0)
        {
            myFoo.setName(args[0]+String.valueOf(myFoo.x));
            System.out.println(myFoo.getName());
        }
        else
        {
            System.out.println("an argument is required!");
            myFoo.setName(String.valueOf(myFoo.x));
            System.out.println(myFoo.getName());
        }
    }
}
