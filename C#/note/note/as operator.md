# `as` operator

The as operator explicitly converts the result of an expression to a given reference or nullable value type. 
If the conversion is not possible, the as operator returns null. 
Unlike a cast expression, the as operator never throws an exception.



正确的选择应该是尽可能地使用as操作符，因为它比强制转型要安全，而且在运行时层面也有比较好的效率
（注意的是as和is操作符都不执行任何用户自定义的转换，只有当运行时类型与目标转换类型匹配时，它们才会转换成功）。

    E as T
    
is equal to
    
    E is T ? (T)(E) : (T)null
