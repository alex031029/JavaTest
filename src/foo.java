public class foo {
    string name;
    public foo (String input) {
        if (input == "") {
            name = "nil"
        }
        else {
            name = input;
        }
    }
    public void setName (String name) {
        this.name = name;
    }
    public String getName () {
        return name
    }
}
