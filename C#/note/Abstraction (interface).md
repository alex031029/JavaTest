# Abstraction

Data abstraction 可以用abstract classes 或者 interfaces来实现。

## Abstract Classes and Methods

C++里的的**纯虚函数**（pure virtual function）是一中abstract method。
即asbtract修饰符下并没有任何实现。

* **Abstract class**: is a restricted class that cannot be used to create objects (to access it, it must be inherited from another class).
* **Abstract method**: can only be used in an abstract class, and it does not have a body. The body is provided by the derived class (inherited from).

The `abstract` modifier indicates that the thing being modified has a missing or incomplete implementation. 

Abstract classes有以下的性质：

1. abstract class无法实例化
1. abstract class可以包含asbtract method跟accessor (accessor是properties中的概念)
1. sealed修饰符复发用在abstract class上。因为这两个修饰符有着完全相反的定义
1. 一个从abstract class继承的non-asbtract class必须包括对于所有的asbtract methods以及accessor的实现

Abstract methods有以下性质：

* abstract method必然是virtual method
* abstract method只能存在于abstract class中
* 因为abstract method没有实现，所以写起来如下
        
        public abstract void MyMethod();

* abstract method的实现由methods override来提供。这个method必然是一个non-abstract class中的成员。
* static跟virtual修饰符不能用在abstract method之前


## Interface

An interface is a completely "**abstract class**", which can only contain abstract methods and properties (with empty bodies):

Example：

    // Interface
    interface IAnimal 
    {
      void animalSound(); // interface method (does not have a body)
    }

    // Pig "implements" the IAnimal interface
    class Pig : IAnimal 
    {
      public void animalSound() 
      {
        // The body of animalSound() is provided here
        Console.WriteLine("The pig says: wee wee");
      }
    }

    class Program 
    {
      static void Main(string[] args) 
      {
        Pig myPig = new Pig();  // Create a Pig object
        myPig.animalSound();
      }
    }

> :warning:  It is considered good practice to start with the letter "I" at the beginning of an interface, as it makes it easier for yourself and others to remember that it is an interface and not a class.
>
>  By default, members of an interface are `abstract` and `public`.
>
>  Note: Interfaces can contain properties and methods, but not fields.


