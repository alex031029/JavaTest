public class Foo {
    private String name;
    final int x;
    public Foo (String input) {
        System.out.println("A new foo is created!");
        if (input.equals("")) {
            name = "nil";
            x = 0;
        }
        else {
            name = input;
            x = 1;
        }
    }
    public void setName (String name) {
        this.name = name;
    }
    public String getName () {
        return name;
    }
}
