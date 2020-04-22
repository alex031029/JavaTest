# using关键词

using关键词有三个用法

* using语句 （using statement）
* using指令 （directive）
* using static 指令 (using static directive)

## using statement

提供可确保正确使用 IDisposable 对象的方便语法。 从 C#8.0 开始，using 语句可确保正确使用 IAsyncDisposable 对象。

使用using语句，定义一个范围，在范围结束时处理对象。(不过该对象必须实现了IDisposable接口)。其功能和try ,catch,Finally完全相同。
using使用的对象必须实现IDisposable接口。

*IDisposable Interface*: Provides a mechanism for releasing unmanaged resources.

## suing directive

就是命名空间那套，导入其他命名空间中定义的类型。
