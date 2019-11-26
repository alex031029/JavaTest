# Some Notes When Learning JAVA

1. **String** is capitalized while **int** is not.
    * It is because String is a class.
    * While int, boolean etc. are primitive type
    * https://blog.csdn.net/xionghuimin/article/details/95453181

2. The *main* function must be static.
    * Otherwise the compiler will raise an error. 

3. The static function cannot modify or assign non-static variables
    * Like the main function cannot assign a variable directly, unless the variable is also static.
    * We can construct two functions to circumvent this issue.
        1. getXXX()
        2. setXXX()
    * It works basically like other C++ class when modifying private variables.
    