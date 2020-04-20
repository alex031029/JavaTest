# Abstraction

Data abstraction 可以用abstract classes 或者 interfaces来实现。

## Abstract Classes and Methods

C++里的的纯虚函数就是一中abstract class。

* **Abstract class**: is a restricted class that cannot be used to create objects (to access it, it must be inherited from another class).
* **Abstract method**: can only be used in an abstract class, and it does not have a body. The body is provided by the derived class (inherited from).


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
