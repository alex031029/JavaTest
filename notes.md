# Some Notes When Learning JAVA

1. `String` is capitalized while `int` is not.
    * It is because String is a class.
    * While int, boolean etc. are primitive type
    * https://blog.csdn.net/xionghuimin/article/details/95453181

2. The `main` function must be static.
    * Otherwise the compiler will raise an error. 
    * To be specific, the main function must be 
        * public
        * static
        * void
    * The `args[0]` of main function is simply the first argument, rather than the file name or path, which is different from C++.

3. The static function cannot modify or assign non-static variables
    * Like the main function cannot assign a variable directly, unless the variable is also static.
    * We can construct two functions to circumvent this issue.
        1. getXXX()
        2. setXXX()
    * It works basically like other C++ class when modifying private variables.
    
4. Comparison of two `String` variables using `==` or `equals`?
    * `==` compares two Strings' object references. 
    * `equals` compares the contents of the Strings.
    * It looks like comparing strings of `char *` in C, using either the pointer or `strcmp()`.
    
5. `java.lang` defines basic types and classes like `Byte` and `String`.
    * We can call constants like `Byte.SIZE` to check the detailed configurations.
    
6. Modifiers:
    * `final`: used for variables. It cannot changed once it is assigned for the first time. 