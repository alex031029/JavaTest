# Access Modifier

中文叫访问修饰符。C++只有public, private与protected三种，在C#里面有六种：

* public: 
* protected: 访问仅限于包含类或者派生自包含类的类型
* internal：访问仅限于当前的程序集（current assembly），属于protected internal的一个子集
* protected internal: 访问限于当前程序集或派生自包含类的类型
* private: 属于private protected的一个子集
* private protected: 访问限于包含类或派生自当前程序集中包含类的类型

**Assembly**: 程序集，形式上是 *.exe*或者 *.dll*文件。
