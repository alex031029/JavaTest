# params (C# Reference)

[MS Docs](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/params)

当我们需要给一个方法制定不确定数量的parameter的时候，我们可以使用`params`关键词。类型必然是一位数组。

例子：

    public class MyClass
    {
        public static void UseParams(params int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }
        
        // object提供了一种最底层的类
        public static void UseParams2(params object[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }

        static void Main()
        {
            // You can send a comma-separated list of arguments of the
            // specified type.
            UseParams(1, 2, 3, 4);
            UseParams2(1, 'a', "test");

            // A params parameter accepts zero or more arguments.
            // The following calling statement displays only a blank line.
            UseParams2();

            // An array argument can be passed, as long as the array
            // type matches the parameter type of the method being called.
            int[] myIntArray = { 5, 6, 7, 8, 9 };
            UseParams(myIntArray);

            object[] myObjArray = { 2, 'b', "test", "again" };
            UseParams2(myObjArray);

            // The following call causes a compiler error because the object
            // array cannot be converted into an integer array.
            //UseParams(myObjArray);

            // The following call does not cause an error, but the entire
            // integer array becomes the first element of the params array.
            UseParams2(myIntArray);
        }
    }
    /*
    Output:
        1 2 3 4
        1 a test

        5 6 7 8 9
        2 b test again
        System.Int32[]
    */
    
    
## 有无`params`的区别

参考这个[link](https://stackoverflow.com/questions/7580277/why-use-the-params-keyword)

以下两种写法都是正确的：

      static public int addTwoEach(params int[] args)
      {
          int sum = 0;
          foreach (var item in args)
              sum += item + 2;
          return sum;
      }


      static public int addTwoEach(int[] args)
      {
          int sum = 0;
          foreach (var item in args)
             sum += item + 2;
          return sum;
      }
      
但是只有使用params，我们可以使用`addTwoEach(1,2,3,4,5)`来调用函数。
同时可以使用`addTwoEach()`，即没有参数传入。
这种情况下，args被是null。
