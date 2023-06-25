# this() Constructor 

[link](https://stackoverflow.com/questions/3797528/base-and-this-constructors-best-practices/3797626)

    class Person
    {
        public Person(string name)
        {
            Debug.WriteLine("My name is " + name);
        }
    }

    class Employee : Person
    {
        public Employee(string name, string job)
            : base(name)
        {
            Debug.WriteLine("I " + job + " for money.");
        }

        public Employee() : this("Jeff", "write code")
        {
            Debug.WriteLine("I like cake.");
        }
    }
    
    var foo = new Person("ANaimi");
    
    // output:
    //  My name is ANaimi

    var bar = new Employee("ANaimi", "cook food");
    // output:
    //  My name is ANaimi
    //  I cook food for money.

    var baz = new Employee();
    // output:
    //  My name is Jeff
    //  I write code for money.
    //  I like cake.
