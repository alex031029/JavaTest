# Fields （字段）

A field is a variable of any type that is declared directly in a class or struct. 
Fields are members of their containing type.

这个定义类似于成员变量与成员函数。

理论上，所有的field变量，都是private或者protected。
可以暴露给外界的数据，应当使用methods, properties或者indexers。

# Properties (属性）

属性是field的扩展。他们使用**访问器（accessors）**来让私有字段的值可以被读或者写操作。

这种方法类似于C++里面的，为一个私有变量专门设置返回值与修改的共有函数。

https://stackoverflow.com/questions/6001917/what-are-automatic-properties-in-c-sharp-and-what-is-their-purpose

Property在各种C#文档中非常常见，比如[Generic.Stack](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.stack-1?view=netcore-3.1)里的`Count`就是Stack的一个property。

调用的时候并不需要括号，只需要

    Stack<int> s = new Stack<int>();
    // some operations
    Console.WriteLine(s.Count);     // no parentheses are needed

例子：

    public class Person
    {
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        private string firstName;
        // remaining implementation removed from listing
    }
    
## Auto-Implemented Properties

    // This class is mutable. Its data can be modified from
    // outside the class.
    class Customer
    {
        // Auto-implemented properties for trivial get and set
        public double TotalPurchases { get; set; }
        public string Name { get; set; }
        public int CustomerID { get; set; }

        // Constructor
        public Customer(double purchases, string name, int ID)
        {
            TotalPurchases = purchases;
            Name = name;
            CustomerID = ID;
        }

        // Methods
        public string GetContactInfo() { return "ContactInfo"; }
        public string GetTransactionHistory() { return "History"; }

        // .. Additional methods, events, etc.
    }

    class Program
    {
        static void Main()
        {
            // Intialize a new object.
            Customer cust1 = new Customer(4987.63, "Northwind", 90108);

            // Modify a property.
            cust1.TotalPurchases += 499.99;
        }
    }

# Indexers (检索器)

感觉有点像C++里的重载[]操作符。
从而可以对一个class进行[]操作，就好像一个数组一样。
