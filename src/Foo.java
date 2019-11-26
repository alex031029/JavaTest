public class Foo {
    private String name;
    public Foo (String input) {
        System.out.println("A new foo is created!");
        if (input.equals("")) {
            name = "nil";
        }
        else {
            name = input;
        }
    }
    public void setName (String name) {
        this.name = name;
    }
    public String getName () {
        return name;
    }
}
