# Generic (泛型)

在Java跟C#中都被叫做泛型，在C++中叫做模板（template）。

The following are the key differences between C# Generics and C++ templates:

* C# generics do not provide the same amount of flexibility as C++ templates. For example, it is not possible to call arithmetic operators in a C# generic class, although it is possible to call user defined operators.

* C# does not allow non-type template parameters, such as template C<int i> {}.

* C# does not support explicit specialization; that is, a custom implementation of a template for a specific type.

* C# does not support partial specialization: a custom implementation for a subset of the type arguments.

* C# does not allow the type parameter to be used as the base class for the generic type.

* C# does not allow type parameters to have default types.

* In C#, a generic type parameter cannot itself be a generic, although constructed types can be used as generics. C++ does allow template parameters.

* C++ allows code that might not be valid for all type parameters in the template, which is then checked for the specific type used as the type parameter. C# requires code in a class to be written in such a way that it will work with any type that satisfies the constraints. For example, in C++ it is possible to write a function that uses the arithmetic operators + and - on objects of the type parameter, which will produce an error at the time of instantiation of the template with a type that does not support these operators. C# disallows this; the only language constructs allowed are those that can be deduced from the constraints.
