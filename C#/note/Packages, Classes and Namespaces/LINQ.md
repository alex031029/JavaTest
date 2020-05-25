# 语言集成查询

Language Integrated Query (LINQ)。LINQ 数据源是支持泛型 IEnumerable<T> 接口或从中继承的接口的任意对象。

有点像SQL。

    class IntroToLINQ
    {
        static void Main()
        {
            // The Three Parts of a LINQ Query:
            // 1. Data source.
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            // 2. Query creation.
            // numQuery is an IEnumerable<int>
            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            // 3. Query execution.
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }
        }
    }
