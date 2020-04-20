# Fields （字段）

A field is a variable of any type that is declared directly in a class or struct. 
Fields are members of their containing type.

这个定义类似于成员变量与成员函数。

理论上，所有的field变量，都是private或者protected。
可以暴露给外界的数据，应当使用methods, properties或者indexers。

# Properties (属性）

属性是field的扩展。他们使用**访问器（accessors）**来让私有字段的值可以被读或者写操作。

这种方法类似于C++里面的，为一个私有变量专门设置返回值与修改的共有函数。

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
    
# Indexers (检索器)

感觉有点像C++里的重载[]操作符。
从而可以对一个class进行[]操作，就好像一个数组一样。
